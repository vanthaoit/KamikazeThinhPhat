using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Model.Models;

namespace KamikazeThinhPhat.Data.Repositories
{
    public interface IOrderDetaiRepository: IRepository<OrderDetail>
    {
    }
    public class OrderDetailRepository: RepositoryBase<OrderDetail>,IOrderDetaiRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    } 
}
