
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaBack.domain.entities;


namespace PruebaTecnicaBack.infrastructure.configuration
{
    public class StoreConfiguration
    {
        public StoreConfiguration(EntityTypeBuilder<Store> entityTypeBuilder)
        {
           entityTypeBuilder.HasKey(x => x.Id);
        }
    }
}