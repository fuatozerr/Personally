using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personally.WebUI.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
