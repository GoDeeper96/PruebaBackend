
using MediatR;
using PruebaTecnicaBack.domain.baseD;

namespace PruebaTecnicaBack.Application.Commands.Store.DeleteStore
{
    public class DeleteStoreCommand : IRequest<BaseResponseDTO>
    {
        public DeleteStoreCommand()
        {

        }
        public Guid Id { get; set; }
    }
}