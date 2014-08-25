namespace Domain.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GuestbookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Guestbook.EF.GuestbookContext";
        }

        protected override void Seed(GuestbookContext context)
        {
        }
    }
}
