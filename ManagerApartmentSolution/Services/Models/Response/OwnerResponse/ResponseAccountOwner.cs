﻿using Domain.Enums.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.OwnerResponse
{
    public class ResponseAccountOwner : AccountResponse
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; } = ROLEACCOUNT.OWNER.ToString();   
        public string? AvatarLink { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastUpdate { get; set; }
        public string? Status { get; set; }
    }
}
