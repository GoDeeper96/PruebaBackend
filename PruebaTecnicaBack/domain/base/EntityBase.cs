using System;
namespace PruebaTecnicaBack.domain.baseD
{
    public abstract class EntityBase
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Deleted { get; set; }
        //public Guid? UserCreated { get; set; }
        //public Guid? UserModified { get; set; }
    }
}
