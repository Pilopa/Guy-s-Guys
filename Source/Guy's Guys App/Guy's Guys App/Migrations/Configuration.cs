namespace Guys_Guys_App.Migrations
{
    using Model.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Guys_Guys_App.DatabaseModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Guys_Guys_App.DatabaseModel context)
        {
            //  This method will be called after migrating to the latest version.

            // Create admin user
            context.Set<User>().AddOrUpdate(
                new User("admin", "admin")
            );
        }
    }
}
