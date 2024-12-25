using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Common;

namespace OnionArch.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
