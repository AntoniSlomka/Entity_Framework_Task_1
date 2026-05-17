using EFCodeFirstTask1.DTOs;
using EFCodeFirstTask1.Repository;

namespace EFCodeFirstTask1.Service
{
    public class PCService : IPCService
    {
        private readonly IRepository repository;

        public PCService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<PCResultDTO>> GetPCs()
        {
            return await repository.GetPCs();
        }

        public async Task<PCResultDTO> GetPC(int id)
        {
            return await repository.GetPC(id);
        }

        public async Task<List<ComponentResultDTO>> GetPCComponents(int id)
        {
            return await repository.GetPCComponents(id);
        }
    }
}
