using MediatR;
using PruebaTecnicaBack.application.repositories;
using PruebaTecnicaBack.domain.baseD;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using PruebaTecnicaBack.domain.entities;

namespace PruebaTecnicaBack.Application.Commands.Store.UpdateStoreCommand
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, BaseResponseDTO>
    {
        private readonly IStoreRepository _storeRepository;

        public UpdateStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<BaseResponseDTO> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseDTO();

            try
            {
       
                var store = await _storeRepository.GetByIdAsync(request.Id);
                if (store == null)
                {
                    response.Confirmacion = false;
                    response.Mensaje = "Tienda no encontrada";
                    return response;
                }

           
                if (!DateTime.TryParseExact(request.OpenTime, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDt) ||
                    !DateTime.TryParseExact(request.CloseTime, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime closeDt))
                {
                    response.Confirmacion = false;
                    response.Mensaje = "Formato de hora inválido. Use hh:mm AM/PM";
                    return response;
                }

             
                store.Name = request.Name;
                store.BannerUrl = request.BannerUrl;
                store.Latitude = request.Latitude;
                store.Longitude = request.Longitude;
                store.OpenTime = openDt.TimeOfDay;
                store.CloseTime = closeDt.TimeOfDay;

              
                await _storeRepository.UpdateAsync(store);

                response.Confirmacion = true;
                response.Mensaje = "Tienda actualizada exitosamente";
            }
            catch (Exception ex)
            {
                response.Confirmacion = false;
                response.Mensaje = $"Error al actualizar la tienda: {ex.Message}";
            }

            return response;
        }
    }
}
