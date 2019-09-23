using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Entities
{
    public class Category:BaseEntity
    {
        public string Title { get; set; }

        public List<NoteCategory> noteCategories { get; set; }
    }
}
