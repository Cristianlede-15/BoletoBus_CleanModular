using BoletoBus_CleanModular.Bus.Application.Interfaces;
using BoletoBus_CleanModular.Cliente.Application.Dtos;
using BoletoBus_CleanModular.Cliente.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BoletoBus_CleanModular.Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = clienteService.GetClientes();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = clienteService.GetCliente(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteSaveDto clienteSaveDto)
        {
            var result = clienteService.SaveCliente(clienteSaveDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(ClienteUpdateDto clienteUpdateDto)
        {
            var result = clienteService.UpdateCliente(clienteUpdateDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ClienteDeleteDto clienteDeleteDto)
        {
            var result = clienteService.DeleteCliente(clienteDeleteDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}
