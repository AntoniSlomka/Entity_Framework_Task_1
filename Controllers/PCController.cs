using EFCodeFirstTask1.DTOs;
using EFCodeFirstTask1.Infrastructure;
using EFCodeFirstTask1.Models;
using EFCodeFirstTask1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstTask1.Controllers
{
    [ApiController]
    [Route("api/pcs")]
    public class PCController : ControllerBase
    {
        private readonly IPCService _service;

            public PCController(IPCService service)
            {
                _service = service;
            }

        [HttpGet]
        public async Task<ActionResult<List<PCResultDTO>>> GetPCs()
        {
            return Ok(await _service.GetPCs());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PCResultDTO>> GetPC(int id)
        {
            var PC = await _service.GetPC(id);

            if (PC is null)
                return NotFound($"PC with id: {id} not found");
            else
                return Ok(PC);
        }

        [HttpGet]
        [Route("{id}/components")]
        public async Task<ActionResult<List<ComponentResultDTO>>> GetPCComponents(int id)
        {
            if (_service.GetPC(id) == null)
                return NotFound($"PC with id {id} was not found.");

            return Ok(await _service.GetPCComponents(id));
        }

    }
}
