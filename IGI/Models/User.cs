﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class User: IdentityUser
    {
       public string Path { get; set; }
        //public int Id { get; set; }
        //public string Username { get; set; }
        //public string Email { get; set; }
    }
}
