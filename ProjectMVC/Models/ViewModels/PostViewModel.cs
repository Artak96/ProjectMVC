using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Models.ViewModels
{
    public class PostViewModel
    {
        public int Price { get; set; }
        public string PostType { get; set; }
        public string Body { get; set; }
        public DateTime PostData { get; set; } = DateTime.Now;
    }
}
