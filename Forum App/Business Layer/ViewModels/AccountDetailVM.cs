﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.ViewModels
{
    public class AccountDetailVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool Administrator { get; set; }
    }
}
