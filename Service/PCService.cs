using EFCodeFirstTask1.DTOs;
using EFCodeFirstTask1.Repository;

namespace EFCodeFirstTask1.Service
{
    public class PCService : IPCService
    {
        private readonly IRepository _repository;

        public PCService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<PCResultDTO>> GetPCs()
        {
            return await _repository.GetPCs();
        }

        public async Task<PCResultDTO> GetPC(int id)
        {
            return await _repository.GetPC(id);
        }

        public async Task<List<ComponentResultDTO>> GetPCComponents(int id)
        {
            return await _repository.GetPCComponents(id);
        }

        public async Task<PCResultDTO> AddPC(PCCreateDTO request)
        {
            return await _repository.AddPC(request);
        }

        public async Task<PCResultDTO> UpdatePC(int id, PCUpdateDTO request)
        {
            return await _repository.UpdatePC(id, request);
        }

        public async Task DeletePc(int id)
        {
            await _repository.DeletePC(id);
        }
    }
}
