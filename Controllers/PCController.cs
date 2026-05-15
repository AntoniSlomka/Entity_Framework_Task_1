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
        public async Task<ActionResult<List<PC>>> GetPCs()
        {
            var PCs = await _context.PCs
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Weight,
                    p.Warranty,
                    p.CreatedAt,
                    p.Stock
                }).ToListAsync();
            return Ok(PCs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PC>> GetPC(int id)
        {
            var PC = await _context.PCs
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Weight,
                    p.Warranty,
                    p.CreatedAt,
                    p.Stock
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
                .Select(v => new
                {
                    Code = v.Compo.Code,
                    Name = v.Compo.Name,
                    Description = v.Compo.Description,
                    Amount = v.PCComp.Amount
                }).ToListAsync();

            return Ok(Components);
        }

    }
}
