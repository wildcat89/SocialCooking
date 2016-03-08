using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialCooking.Domain.Entity
{
    [Table("Dishes")]
    public class Dish
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public string PhotoPath { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Archived { get; set; }
        public bool Published { get; set; }
        public Guid DishDifficultyLevelId { get; set; }
        public Guid DishCategoryId { get; set; }
        public string AuthorId { get; set; }

        public virtual DishDifficultyLevel DifficultyLevel { get; set; }
        public virtual DishCategory DishCategory { get; set; }
    }
}
