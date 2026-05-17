using EFCodeFirstTask1.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirstTask1.Repository
{
    public interface IRepository
    {
        Task<List<PCResultDTO>> GetPCs();

        Task<PCResultDTO> GetPC(int id);

        Task<List<ComponentResultDTO>> GetPCComponents(int id);

        Task<PCResultDTO> AddPC(PCCreateDTO request);

        Task<PCResultDTO> UpdatePC(int id, PCUpdateDTO request);
    }
}
