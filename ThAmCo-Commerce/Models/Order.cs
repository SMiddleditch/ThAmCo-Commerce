﻿using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo_Commerce.Models
{
    public class Order
    {
        [Key]
        public int Id {get; set;}

        public string Email { get; set;}
        public int UserId { get; set; }


        public List<OrderProduct> OrderProduct { get; set; }




    }
}
