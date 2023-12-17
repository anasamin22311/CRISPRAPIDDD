using Application.Services.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _repository;
        private readonly ILogger<ModelService> _logger;

        public ModelService(IModelRepository repository, ILogger<ModelService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> ModelExistsAsync(int id)
        {
            return await _repository.ModelExistsAsync(id);
        }

        public async Task<Model> GetModelAsync(int id)
        {
            return await _repository.GetModelAsync(id);
        }

        public async Task AddModelAsync(Model model)
        {
            _logger.LogInformation("Model ID before saving: {ModelId}", model.id);
            _repository.AddModelAsync(model);
            _logger.LogInformation("Model ID after saving: {ModelId}", model.id);
        }

        public async Task UpdateModelAsync(Model model)
        {
            await _repository.UpdateModelAsync(model);
        }

        public async Task DeleteModelAsync(int id)
        {
            await _repository.DeleteModelAsync(id);
        }

        public async Task<List<Model>> GetAllModelsAsync()
        {
            return await _repository.GetAllModelsAsync();
        }

        public async Task<bool> EntitySetIsNullAsync()
        {
            return await _repository.EntitySetIsNullAsync();
        }
        public async Task<string> GeneratePdfFileAsync(Model model)
        {
            return await _repository.GeneratePdfFileAsync(model);
        }
    }
}
