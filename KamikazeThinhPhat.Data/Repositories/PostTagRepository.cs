using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Model.Models;

namespace KamikazeThinhPhat.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag>
    {
    }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}