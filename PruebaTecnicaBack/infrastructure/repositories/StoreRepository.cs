

using Microsoft.EntityFrameworkCore;
using MiProyectoApi.Models;
using PruebaTecnicaBack.application.repositories;

namespace PruebaTecnicaBack.infrastructure.repositories
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
 
}