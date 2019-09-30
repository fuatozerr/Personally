using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personally.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public int TotalPage()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }

    }

    public class NoteListModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Note> Notes { get; set; }
    }
}
