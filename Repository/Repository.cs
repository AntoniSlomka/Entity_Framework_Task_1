using EFCodeFirstTask1.DTOs;
using EFCodeFirstTask1.Infrastructure;
using EFCodeFirstTask1.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

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

    }
}
