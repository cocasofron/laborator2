using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class CommentGetModel
    {
        public string Text { get; set; }
        public bool Important { get; set; }
        public int MovieId { get; set; }
    }
}
