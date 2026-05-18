using EFCodeFirstTask1.DTOs;

namespace EFCodeFirstTask1.Service
{
    public interface IPCService
    {
        Task<List<PCResultDTO>> GetPCs();
        Task<PCResultDTO> GetPC(int id);

        Task<List<ComponentResultDTO>> GetPCComponents(int id);

        Task<PCResultDTO> AddPC(PCCreateDTO request);

        Task<PCResultDTO> UpdatePC(int id, PCUpdateDTO request);

        Task DeletePc(int id);
    }
}
