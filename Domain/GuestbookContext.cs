using Domain.Models;
using System.Data.Entity;

namespace Domain
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext()
            : base("Guestbook.EF.GuestbookContext")
        {
        }

        public DbSet<Msg> Msgs { get; set; }
    }
}
