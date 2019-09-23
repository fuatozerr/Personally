using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
