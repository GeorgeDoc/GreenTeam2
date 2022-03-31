﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Model
{
    public class Transaction: BaseEntity
    {
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int PetID { get; set; }
        public decimal PetPrice { get; set; }
        public int PetFoodID { get; set; }
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public Transaction()
        {

        }

    }
}
