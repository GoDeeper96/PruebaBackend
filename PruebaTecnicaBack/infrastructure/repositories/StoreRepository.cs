

using Microsoft.EntityFrameworkCore;

using PruebaTecnicaBack.application.repositories;
using PruebaTecnicaBack.domain.entities;

namespace PruebaTecnicaBack.infrastructure.repositories
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
 
}