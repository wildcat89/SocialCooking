using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialCooking.Domain.Abstract;
using SocialCooking.Domain.Context;
using SocialCooking.Domain.Entity;

namespace SocialCooking.Domain.Concrete
{
    public class SCUsersRepository : IUsersRepository
    {
        private readonly SCContext _context = new SCContext();
        public IQueryable<AspNetUsers> Users => _context.AspNetUsers;
        public IQueryable<UsersExtension> UsersExtensions => _context.UsersExtension;
        public async Task<UsersExtension> GetUsersExtensionByIdentityIdAsync(string id)
        {
            UsersExtension user = UsersExtensions.Where(p => p.Users.UserName == id).FirstOrDefault();
            return user;
        }

        public async Task<UsersExtension> SaveProfileImagePath(string username, string path, string thumbPath)
        {
            UsersExtension user = UsersExtensions.Where(p => p.Users.UserName == username).FirstOrDefault();
            user.ImagePath = path;
            user.ImageThumbPath = thumbPath;
            _context.SaveChanges();
            return user;
        }
    }
}
