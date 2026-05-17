using EFCodeFirstTask1.DTOs;
using EFCodeFirstTask1.Infrastructure;
using EFCodeFirstTask1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstTask1.Controllers
{
    [ApiController]
    [Route("api/pcs")]
    public class PCController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PCController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PCResultDTO>>> GetPCs()
        {
            var PCs = await _context.PCs
                .Select(p => new PCResultDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Weight = p.Weight,
                    Warranty = p.Warranty,
                    CreatedAt = p.CreatedAt,
                    Stock = p.Stock
                }).ToListAsync();
            return Ok(PCs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PCResultDTO>> GetPC(int id)
        {
            var PC = await _context.PCs
                .Where(p => p.Id == id)
                .Select(p => new PCResultDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Weight = p.Weight,
                    Warranty = p.Warranty,
                    CreatedAt = p.CreatedAt,
                    Stock = p.Stock
                }).FirstOrDefaultAsync();

            if (PC is null)
                return NotFound($"PC with id: {id} not found");
            else
                return Ok(PC);
        }

        [HttpGet]
        [Route("{id}/components")]
        public async Task<ActionResult<List<Component>>> GetPCComponents(int id)
        {
            var pcExists = await _context.PCs.AnyAsync(p => p.Id == id);

            if (!pcExists)
                return NotFound($"PC with id {id} was not found.");

            var Components = await _context.PCComponents
                .Where(pc => pc.PCId == id)
                .Join(_context.Components,
                    pc => pc.ComponentCode,
                    c => c.Code,
                    (pc, c) => new { PCComp = pc, Compo = c })
                .Join(_context.ComponentTypes,
                    v => v.Compo.ComponentTypeId,
                    ct => ct.Id,
                    (v, ct) => new { v.PCComp, v.Compo, CompType = ct })
                .Join(_context.ComponentManufacturers,
                    v => v.Compo.ComponentManufacturerId,
                    m => m.Id,
                    (v, m) => new { v.PCComp, v.Compo, v.CompType, CompManu = m })
                .Select(v => new ComponentResultDTO
                {
                    Code = v.Compo.Code,
                    Name = v.Compo.Name,
                    Type = v.CompType.Name,
                    Manufacturer = v.CompManu.Abbreviation,
                    Description = v.Compo.Description,
                    Amount = v.PCComp.Amount
                }).ToListAsync();

            return Ok(Components);
        }

    }
}
