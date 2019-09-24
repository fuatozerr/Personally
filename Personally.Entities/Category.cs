using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<NoteCategory> noteCategories { get; set; }
    }
}
