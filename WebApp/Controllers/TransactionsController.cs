using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel=new TransactionsViewModel();
            
            return View(transactionsViewModel);
        }
        public IActionResult Search(TransactionsViewModel transactionsViewModel, TransactionsRepository transactionsRepository)
        {
            var transactions = transactionsRepository.Search(transactionsViewModel.CashierName??string.Empty,
                transactionsViewModel.StarDate,
                transactionsViewModel.EndDate);
            transactionsViewModel.Transactions = transactions;
            return View("Index",transactionsViewModel);
        }
    }
}
