using System.Collections.Generic;
using System.Threading.Tasks;
using Inlämning3Docker.Models;

namespace Inlämning3Docker.Services;
public interface IDbService
{
    Task<IEnumerable<DbItem>> GetAllAsync();
    Task<DbItem> CreateAsync(DbItem item);
    Task DeleteAsync(string id);
}
