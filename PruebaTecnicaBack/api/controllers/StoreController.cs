
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBack.Application.Commands.Store.CreateStore;
using PruebaTecnicaBack.Application.Commands.Store.DeleteStore;
using PruebaTecnicaBack.Application.Commands.Store.Listar;
using PruebaTecnicaBack.Application.Commands.Store.UpdateStoreCommand;
using PruebaTecnicaBack.domain.baseD;

namespace PruebaTecnicaBack.api.controllers
{
    [Route("api/v1/[controller]")]
    public class StoreController : Controller
    {
        private readonly IMediator _mediator;
        public StoreController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost(Name = "Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] CreateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("Delete", Name = "Delete store by Id")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> EliminarCurso([FromBody] DeleteStoreCommand command)
        {
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }


        [HttpPut("Update", Name = "Update Store")]
        [ProducesResponseType(typeof(BaseResponseDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseDTO>> EditarCurso([FromBody] UpdateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpGet("ListStores", Name = "List stores")]
            [ProducesResponseType((int)HttpStatusCode.OK)]
            public async Task<ActionResult<ListStoreDTO>> ListarTiendas()
            {
                var query = new ListStoreQuery(); 
                var result = await _mediator.Send(query);
                return Ok(result);
            }
        }
     
}