﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class TransactionsViewModel
    {
        [Display(Name = "Cashier Name")]
        public string? CashierName { get; set; }
        [Display(Name = "Star Date ")]
        public DateTime StarDate { get; set; }= DateTime.Today;
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;
        public IEnumerable<Transaction> Transactions { get; set; }= new List<Transaction>();


    }
}
