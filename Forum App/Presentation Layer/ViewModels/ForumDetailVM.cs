using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.ViewModels
{
    public class ForumDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorID { get; set; }
        public AccountDetailVM Creator { get; set; } = new AccountDetailVM();
        public AccountDetailVM account { get; set; } = new AccountDetailVM();
        public List<PostDetailVM> posts { get; set; } = new List<PostDetailVM>();
    }
}
