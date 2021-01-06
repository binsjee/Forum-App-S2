using Database_Layer.DTO_s;
using Database_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IPostContext : IGenericQueries<PostDTO>, IPostUpdateContext
    {
        long Insert(PostDTO dto);
        bool Delete(PostDTO dto);
    }
}
