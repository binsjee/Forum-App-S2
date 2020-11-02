using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation_Layer.ViewModels
{
    public class PostDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string PostTime { get; set; }
        public int AccountId { get; set; }
    }
}
