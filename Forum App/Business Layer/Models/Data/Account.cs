﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool Administrator { get; set; }
        public Account(int id, string firstname, string lastname, string email, string password, string username, bool admin)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            Username = username;
            Administrator = admin;
        }
    }
}
