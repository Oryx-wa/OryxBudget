﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OryxBudgetWeb.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string MemberRole { get; set; }
        public string Role { get; set; }
        public string OperatorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Level { get; set; }
        public bool SubCom { get; set; }
        public bool TecCom { get; set; }
        public bool MalCom { get; set; }
        public bool Final { get; set; }


    }
}
