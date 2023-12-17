using Domain.Models;
using Microsoft.Extensions.Logging;
using Infrastructure.Repositories;
using Application.Services.Interfaces;

namespace Application.Services
{
    public class DataSetService : IDataSetService
    {
        private readonly IDataSetRepository _repository;
        private readonly ILogger<DataSetService> _logger;

        public DataSetService(IDataSetRepository repository, ILogger<DataSetService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> DataSetExistsAsync(int id)
        {
            return await _repository.DataSetExistsAsync(id);
        }

        public async Task<DataSet> GetDataSetAsync(int id)
        {
            return await _repository.GetDataSetAsync(id);
        }

        public async Task AddDataSetAsync(DataSet dataSet)
        {
            _logger.LogInformation("DataSet ID before saving: {DataSetId}", dataSet.id);
            _repository.AddDataSetAsync(dataSet);
            _logger.LogInformation("DataSet ID after saving: {DataSetId}", dataSet.id);
        }

        public async Task UpdateDataSetAsync(DataSet dataSet)
        {
            await _repository.UpdateDataSetAsync(dataSet);
        }

        public async Task DeleteDataSetAsync(int id)
        {
            await _repository.DeleteDataSetAsync(id);
        }

        public async Task<List<DataSet>> GetAllDataSetsAsync()
        {
            return await _repository.GetAllDataSetsAsync();
        }

        public async Task<bool> EntitySetIsNullAsync()
        {
            return await _repository.EntitySetIsNullAsync();
        }
        public async Task<string> GeneratePdfFileAsync(DataSet dataSet)
        {
            return await _repository.GeneratePdfFileAsync(dataSet);
        }
    }
}
