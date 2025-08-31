using MediatR;
using PruebaTecnicaBack.domain.baseD;

namespace PruebaTecnicaBack.Application.Commands.Store.CreateStore
{
    public class CreateStoreCommand : IRequest<BaseResponseDTO>
    {

        public CreateStoreCommand()
        {
            
        }
        public string Name { get; set; }
        public string BannerUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string OpenTime { get; set; }

        public string CloseTime { get; set; }
        
    }
}