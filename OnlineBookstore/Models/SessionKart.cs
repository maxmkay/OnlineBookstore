using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookstore.Infrastructure;

namespace OnlineBookstore.Models
{
    public class SessionKart : Kart
    {
        public static Kart GetKart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionKart kart = session?.GetJson<SessionKart>("Kart") ?? new SessionKart();

            kart.Session = session;

            return kart;

        }

        [JsonIgnore]
        public ISession Session { get; set; }


        public override void AddItem(Books books, int qty)
        {
            base.AddItem(books, qty);
            Session.SetJson("Kart", this);
        }

        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            Session.SetJson("Kart", this);
        }

        public override void ClearKart()
        {
            base.ClearKart();
            Session.Remove("Kart");
        }
    }
}
