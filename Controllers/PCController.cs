using EFCodeFirstTask1.DTOs;
using EFCodeFirstTask1.Exceptions;
using EFCodeFirstTask1.Infrastructure;
using EFCodeFirstTask1.Models;
using EFCodeFirstTask1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;

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
            try
            {
                var PC = await _service.GetPC(id);

                return Ok(PC);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpGet]
        [Route("{id}/components")]
        public async Task<ActionResult<List<ComponentResultDTO>>> GetPCComponents(int id)
        {
            try
            {
                return Ok(await _service.GetPCComponents(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }           

        }

        [HttpPost]
        public async Task<ActionResult<PCResultDTO>> CreatePC(PCCreateDTO request)
        {
            var pc = await _service.AddPC(request);

            return CreatedAtAction(nameof(GetPC), new { pc.Id }, pc);
        }

        [HttpPut]
        [Route("/{id}")]
        public async Task<ActionResult<PCResultDTO>> UpdatePC(int id, PCUpdateDTO request)
        {
            try
            {
                var pc = _service.UpdatePC(id, request);
                return Ok(pc);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }            
        }

        [HttpDelete]
        [Route("/{id}")]
        public async Task<ActionResult> DeletePC(int id)
        {
            try
            {
                await _service.DeletePc(id);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }

    }
}
