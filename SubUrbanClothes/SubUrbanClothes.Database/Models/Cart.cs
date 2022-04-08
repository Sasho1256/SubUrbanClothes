using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubUrbanClothes.Database.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public string? AspNetUser_Id { get; set; }
        public IdentityUser User { get; set; }

    }
}
