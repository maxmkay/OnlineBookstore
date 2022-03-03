using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookstore.Controllers
{
    public class KartController : Controller
    {
        public IOrderRepository repo { get; set; }
        private Kart kart { get; set; }

        public KartController(IOrderRepository temp, Kart k)
        {
            repo = temp;
            kart = k;
        }

      
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (kart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your Cart is empty");
            }

            if (ModelState.IsValid)
            {
                order.Lines = kart.Items.ToArray();
                repo.SaveOrder(order);
                kart.ClearKart();

                return RedirectToPage("/OrderCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
