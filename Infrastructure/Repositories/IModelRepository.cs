using Domain.Models;

namespace Infrastructure.Repositories
{
    public interface IModelRepository
    {
        Task<bool> ModelExistsAsync(int id);
        Task<Model> GetModelAsync(int id);
        Task AddModelAsync(Model model);
        Task UpdateModelAsync(Model model);
        Task DeleteModelAsync(int id);
        Task<List<Model>> GetAllModelsAsync();
        Task<bool> EntitySetIsNullAsync();
        Task<string> GeneratePdfFileAsync(Model model);

    }
}
