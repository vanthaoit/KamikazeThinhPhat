using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Model.Models;

namespace KamikazeThinhPhat.Data.Repositories
{
    public interface IPartnerRepository : IRepository<Partner>
    {
    }

    public class PartnerRepository : RepositoryBase<Partner>, IPartnerRepository
    {
        public PartnerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}