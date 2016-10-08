namespace KamikazeThinhPhat.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private KamikazeThinhPhatDbContext dbContext;

        public KamikazeThinhPhatDbContext Init()
        {
            return dbContext ?? (dbContext = new KamikazeThinhPhatDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}