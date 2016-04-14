using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using ImageResizer;
using Newtonsoft.Json;
using SocialCooking.API.Models;
using SocialCooking.Domain.Abstract;
using SocialCooking.Domain.Entity;

namespace SocialCooking.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Profile")]
    public class ProfileController : ApiController
    {
        private IUsersRepository _usersRepo;
        public ProfileController(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public async Task<HttpResponseMessage> GetProfileById(string Id)
        {
            UsersExtension user = await _usersRepo.GetUsersExtensionByIdentityIdAsync(Id);
            Mapper.CreateMap<UsersExtension, ProfileViewModel>();
            ProfileViewModel profileVm = Mapper.Map<UsersExtension, ProfileViewModel>(user);

            return Request.CreateResponse(HttpStatusCode.OK, profileVm);
        }


        [HttpPost]
        public async Task<HttpResponseMessage> UploadImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            var uploadFolder = "~/Resource/ImageFiles";
            var provider = GetMultipartProvider(uploadFolder);
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            var originalFileName = GetDeserializedFileName(result.FileData.First());

            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);

            var username = GetFormData(result);
            var destDir = uploadFolder + "/" + username;
            var destPath = destDir + "/" + originalFileName;


            var destLocalDir = HttpContext.Current.Server.MapPath(destDir);
            var destLocalPath = HttpContext.Current.Server.MapPath(destPath);
            string host = Request.GetRequestContext().Url.Request.Headers.Host;
            var destThumbPath = destDir + "/" + originalFileName.Split('.')[0] + "_thumb." +
                                originalFileName.Split('.')[1];

            var destLocalThumbPath = HttpContext.Current.Server.MapPath(destThumbPath);

            Directory.CreateDirectory(destLocalDir);
            File.Move(uploadedFileInfo.FullName, destLocalPath);
            ResizeSettings settings = new ResizeSettings("width=100&height=100");
            ImageBuilder builder = ImageBuilder.Current;

            builder.Build(destLocalPath, destLocalThumbPath, settings);
            var user = await
                _usersRepo.SaveProfileImagePath(username, destPath.Replace("~", "http://"+host), destThumbPath.Replace("~", "http:/ /" + host));
            var returnData = "ImageUploaded";
            return this.Request.CreateResponse(HttpStatusCode.OK, new { returnData });
        }

        private MultipartFormDataStreamProvider GetMultipartProvider(string uploadFolder)
        {
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }

        private string GetFormData(MultipartFormDataStreamProvider result)
        {
            if (result.FormData.HasKeys())
            {
                if (result.FormData.AllKeys.Any(p => p == "username"))
                {
                    return result.FormData.GetValues(0).FirstOrDefault();
                }
            }

            return string.Empty;
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }

    }
}
