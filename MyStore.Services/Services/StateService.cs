using System.Collections.Generic;
using System.Threading.Tasks;
using MyStore.Common.Contracts;
using MyStore.Domain.Repositories;
using MyStore.Services.Contracts.State;
using MyStore.Services.Framework;
using MyStore.Services.Mapping;

namespace MyStore.Services.Services
{
    public interface IStateService : IService
    {
        Task<StateDto> GetAsync(int userId, int id);
        Task<IList<StateDto>> GetAsync(int userId, PagingOptions pagingOptions);
    }

    public class StateService : Service, IStateService
    {
        private readonly IStateRepository _addressRepository;

        public StateService(IStateRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<StateDto> GetAsync(int userId, int id)
        {
            var model = await _addressRepository.GetAsync(userId, id);
            var result = StateDtoMapper.Map(model);

            return result;
        }

        public async Task<IList<StateDto>> GetAsync(int userId, PagingOptions pagingOptions)
        {
            var models = await _addressRepository.GetAsync(userId, null, pagingOptions);
            var results = StateDtoMapper.Map(models);

            return results;
        }
    }
}
