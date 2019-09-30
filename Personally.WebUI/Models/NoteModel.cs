using Personally.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personally.WebUI.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Ürün ismi 3 ile 60 arası olmalı")]
        public string Title { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }
        public string Owner { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Ürün ismi 10 ile 60 arası olmalı")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
