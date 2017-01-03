namespace KamikazeThinhPhat.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KamikazeThinhPhat.Data.KamikazeThinhPhatDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KamikazeThinhPhat.Data.KamikazeThinhPhatDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            CreateContactDetail(context);
        }
        private void CreateContactDetail(KamikazeThinhPhatDbContext context)
        {
            if(context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new KamikazeThinhPhat.Model.Models.ContactDetail()
                    {
                        Name = "Công ty Cổ phần khảo sát và xây dựng công trình Thịnh Phát",
                        Phone = "0983.977.697",
                        Address = "537 Đường 24, lô B, Khu đô thị An Phú, Phường An Phú, Quận 2, Tp.HCM",
                        Lat = 10.7972443,
                        Lng = 106.7408446,
                        Other = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }
    }
}