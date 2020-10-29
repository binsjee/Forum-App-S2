using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.ViewModels
{
    public class PostDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public long postNumber { get; set; }
        public int AccountId { get; set; }
    }
}
