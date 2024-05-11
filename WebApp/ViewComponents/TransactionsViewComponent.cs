using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactionsRepository = new TransactionsRepository();
            var transactions = transactionsRepository.GetByDayAndCashier(userName, DateTime.Now);
            return View(transactions);
        }
        //public IViewComponentResult Invoke(string userName)
        //{
        //    var transaction = TransactionsRepository.GetByDayAndCachier(userName,DateTime.Now);
        //    return View(transaction);
        //}
    }
}
