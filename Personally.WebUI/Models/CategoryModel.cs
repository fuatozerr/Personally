using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personally.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Note> Notes{ get; set; }
    }
}
