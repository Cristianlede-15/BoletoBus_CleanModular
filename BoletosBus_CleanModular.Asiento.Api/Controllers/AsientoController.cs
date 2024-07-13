using Microsoft.AspNetCore.Mvc;
using BoletoBus_CleanModular.Asiento.Application.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletoBus_CleanModular.Asiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoService asientoService;

        public AsientoController(IAsientoService asientoService)
        {
            this.asientoService = asientoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = asientoService.GetAsientos();
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
            var result = asientoService.GetAsiento(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AsientoSaveDto asientoSaveDto)
        {
            var result = asientoService.SaveAsiento(asientoSaveDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(AsientoUpdateDto asientoUpdateDto)
        {
            var result = asientoService.UpdateAsientos(asientoUpdateDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(AsientoDeleteDto asientoDeleteDto)
        {
            var result = asientoService.DeleteAsiento(asientoDeleteDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}
