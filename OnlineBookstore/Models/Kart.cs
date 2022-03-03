using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using OnlineBookstore.Models;

namespace OnlineBookstore.Models
{
    public class Kart
    {
    
        public List<KartLineItem> Items { get; set; } = new List<KartLineItem>();

        public virtual void AddItem (Books books, int qty)
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

        public virtual void RemoveItem(Books book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearKart()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }



    public class KartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }
}
