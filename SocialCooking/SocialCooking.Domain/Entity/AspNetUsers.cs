using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialCooking.Domain.Entity
{
    public class AspNetUsers
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UsersExtension> UsersExtensions { get; set; }
    }
}
