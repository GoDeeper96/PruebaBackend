using MediatR;
using PruebaTecnicaBack.application.repositories;
using PruebaTecnicaBack.domain.baseD;
using System.Globalization;
using System.Net;

namespace PruebaTecnicaBack.Application.Commands.Store.CreateStore
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, BaseResponseDTO>
    {
        private readonly IStoreRepository _storeRepository;

        public CreateStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<BaseResponseDTO> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseDTO();
            try
            {
        
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    response.Mensaje = "El nombre de la tienda es obligatorio";
                    return response;
                }
                if (!DateTime.TryParseExact(request.OpenTime, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDt) ||
                    !DateTime.TryParseExact(request.CloseTime, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime closeDt))
                {
                    response.Confirmacion = false;
                    response.Mensaje = "Formato de hora inválido. Use hh:mm AM/PM";
                    return response;
                }

         
                var store = new domain.entities.Store
                {
                    Name = request.Name,
                    BannerUrl = request.BannerUrl,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    OpenTime = openDt.TimeOfDay,   // <-- TimeSpan
                    CloseTime = closeDt.TimeOfDay  // <-- TimeSpan
                };

          
                await _storeRepository.AddAsync(store);

         
                response.Confirmacion = true;
                response.Mensaje = "Tienda creada exitosamente";
      
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return response;     
        }
    }
}

