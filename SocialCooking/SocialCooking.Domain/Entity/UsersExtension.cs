using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialCooking.Domain.Entity
{
    public class UsersExtension
    {
        [Key]
        public Guid Id { get; set; }
        public string UsersId { get; set; }
        public string ImagePath { get; set; }
        public string ImageThumbPath { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLogin { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public virtual AspNetUsers Users { get; set; }
    }
}
