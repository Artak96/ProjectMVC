using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int Price { get; set; }
        public string PostType { get; set; }
        public string Body { get; set; }
        public DateTime PostData { get; set; }
        public bool IsDeleted { get; set; }
    }
}
