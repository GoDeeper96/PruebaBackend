


using MediatR;
using PruebaTecnicaBack.application.repositories;
using PruebaTecnicaBack.Application.Commands.Store.DeleteStore;
using PruebaTecnicaBack.domain.baseD;
using PruebaTecnicaBack.infrastructure.repositories;

namespace PruebaTecnicaBack.application.Commands.Store.DeleteStore
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, BaseResponseDTO>
    {
        private readonly IStoreRepository _storeRepository;
        public DeleteStoreCommandHandler(StoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<BaseResponseDTO> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
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

               
                await _storeRepository.DeleteAsync(store);

                response.Confirmacion = true;
                response.Mensaje = "Tienda eliminada exitosamente";
            }
            catch (Exception ex)
            {
                response.Confirmacion = false;
                response.Mensaje = $"Error al eliminar la tienda: {ex.Message}";
            }

            return response;
        }
    }
}