﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User : IdentityUser<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}