using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Entities
{
   public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Comment> Comments { get; set; }
        public List<NoteCategory> noteCategories { get; set; }
        public int CategoryId { get; set; }

    }
}
