using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO_s
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool Administrator { get; set; }
        public AccountDTO(int id)
        {
            Id = id;
        }
        public AccountDTO()
        {

        }
    }
}
