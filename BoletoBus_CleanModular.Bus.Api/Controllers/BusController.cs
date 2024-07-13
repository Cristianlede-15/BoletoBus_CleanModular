using BoletoBus_CleanModular.Bus.Application.Dtos;
using BoletoBus_CleanModular.Bus.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BoletoBus_CleanModular.Bus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService busService;

        public BusController(IBusService busService)
        {
            this.busService = busService;
        }




        [HttpGet]
        public IActionResult Get()
        {
            var result = busService.GetBuses();
            if (!result.Success)
            {
                return BadRequest(result);
            }else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = busService.GetBus(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BusSaveDto busSaveDto)
        {
            var result = busService.SaveBus(busSaveDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(BusUpdateDto busUpdateDto)
        {
            var result = busService.UpdateBuses(busUpdateDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(BusDeleteDto busDeleteDto)
        {
            var result = busService.DeleteBus(busDeleteDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }
}
