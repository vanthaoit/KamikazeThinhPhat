using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Model.Models;

namespace KamikazeThinhPhat.Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    {
    }

    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}