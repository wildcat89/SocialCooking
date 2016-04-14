using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialCooking.Domain.Entity;

namespace SocialCooking.Domain.Abstract
{
    public interface IUsersRepository
    {
        IQueryable<AspNetUsers> Users { get; }
        IQueryable<UsersExtension> UsersExtensions { get; }

        Task<UsersExtension> GetUsersExtensionByIdentityIdAsync(string id);
        Task<UsersExtension> SaveProfileImagePath(string username, string path, string thumbPath);
    }
}
