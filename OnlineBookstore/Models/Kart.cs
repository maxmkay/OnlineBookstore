using System;
using System.Collections.Generic;
using System.Linq;
using OnlineBookstore.Models;

namespace OnlineBookstore.Models
{
    public class Kart
    {
    
        public List<KartLineItem> Items { get; set; } = new List<KartLineItem>();

        public void AddItem (Books books, int qty)
        {
            KartLineItem line = Items
                .Where(b => b.Book.BookId == books.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new KartLineItem
                {
                    Book = books,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }



    public class KartLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }
}
