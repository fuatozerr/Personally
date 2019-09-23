using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Entities
{
    public class NoteCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
