using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.ViewModels
{
    public class PostViewModel
    {
        public List<PostDetailVM> PostViewModels { get; set; } = new List<PostDetailVM>();
        public AccountDetailVM account { get; set; } = new AccountDetailVM();
    }
}
