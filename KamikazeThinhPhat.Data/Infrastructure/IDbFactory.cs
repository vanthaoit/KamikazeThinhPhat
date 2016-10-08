using System;

namespace KamikazeThinhPhat.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KamikazeThinhPhatDbContext Init();
    }
}