using EFCodeFirstTask1.DTOs;
using EFCodeFirstTask1.Infrastructure;
using EFCodeFirstTask1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstTask1.Repository
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<PCResultDTO>> GetPCs()
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
            return PCs;
        }

        public async Task<PCResultDTO> GetPC(int id)
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

            return PC;
        }

        public async Task<List<ComponentResultDTO>> GetPCComponents(int id)
        {
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

            return Components;
        }

        public async Task<PCResultDTO> AddPC(PCCreateDTO request)
        {
            var pc = new PC
            {
                Name = request.Name,
                Weight = request.Weight,
                Warranty = request.Warranty,
                CreatedAt = request.CreatedAt,
                Stock = request.Stock
            };

            _context.PCs.Add(pc);
            await _context.SaveChangesAsync();
            return new PCResultDTO
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            };

        }

        public async Task<PCResultDTO> UpdatePC(int id, PCUpdateDTO request)
        {
            var pc = await _context.PCs
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (pc == null) return null;

            pc.Name = request.Name ?? pc.Name;
            pc.Weight = request.Weight ?? pc.Weight;
            pc.Warranty = request.Warranty ?? pc.Warranty;
            pc.CreatedAt = request.CreatedAt ?? pc.CreatedAt;
            pc.Stock = request.Stock ?? pc.Stock;

            await _context.SaveChangesAsync();

            return new PCResultDTO
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            };
        }

    }
}
