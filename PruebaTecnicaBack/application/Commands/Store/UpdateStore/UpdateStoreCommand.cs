
using MediatR;
using PruebaTecnicaBack.domain.baseD;

namespace PruebaTecnicaBack.Application.Commands.Store.UpdateStoreCommand
{
    public class UpdateStoreCommand : IRequest<BaseResponseDTO>
    {
        public UpdateStoreCommand()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BannerUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string OpenTime { get; set; }

        public string CloseTime { get; set; }

    }
}