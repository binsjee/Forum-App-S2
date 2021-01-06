using Database_Layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Layer.Interfaces
{
    public interface IPostUpdateContext
    {
        public bool PostUpdate(PostDTO dto);
    }
}
