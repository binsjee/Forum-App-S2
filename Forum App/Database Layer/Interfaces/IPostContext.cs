using Database_Layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IPostContext : IGenericQueries<PostDTO>
    {
        long Insert(PostDTO dto);
        void Delete(PostDTO dto);
    }
}
