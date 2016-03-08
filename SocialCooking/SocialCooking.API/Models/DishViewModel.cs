using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCooking.API.Models
{
    public class DishViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public string PhotoPath { get; set; }
        public bool Archived { get; set; }
        public bool Published { get; set; }
        public Guid DishDifficultyLevelId { get; set; }
        public Guid DishCategoryId { get; set; }
        public string AuthorId { get; set; }
    }
}