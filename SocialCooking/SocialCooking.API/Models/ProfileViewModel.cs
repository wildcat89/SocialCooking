using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCooking.API.Models
{
    public class ProfileViewModel
    {
        public string UsersId { get; set; }
        public string UsersEmail { get; set; }
        public string UsersPhoneNumber { get; set; }
        public string UsersUserName { get; set; }
        public string ImagePath { get; set; }
        public string ImageThumbPath { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLogin { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}