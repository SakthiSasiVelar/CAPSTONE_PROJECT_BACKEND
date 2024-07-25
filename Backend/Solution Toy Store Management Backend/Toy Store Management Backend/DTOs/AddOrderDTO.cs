﻿using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.DTOs
{
    public class AddOrderDTO
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string TotalAmount { get; set; }

        public string Address { get; set; }

        public int Pincode { get; set; }

        public string DeliveryCharge { get; set; }

        public int? SuccessFulPaymentId { get; set; }
    }
}
