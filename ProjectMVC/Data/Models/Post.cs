using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Data.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int Price { get; set; }
        public string PostType { get; set; }
        public string Body { get; set; }
        public DateTime PostData { get; set; }
        public bool IsDeleted { get; set; }
    }
}
