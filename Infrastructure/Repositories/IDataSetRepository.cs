using Domain.Models;

namespace Infrastructure.Repositories
{
    public interface IDataSetRepository
    {
        Task<bool> DataSetExistsAsync(int id);
        Task<DataSet> GetDataSetAsync(int id);
        Task AddDataSetAsync(DataSet dataSet);
        Task UpdateDataSetAsync(DataSet dataSet);
        Task DeleteDataSetAsync(int id);
        Task<List<DataSet>> GetAllDataSetsAsync();
        Task<bool> EntitySetIsNullAsync();
        Task<string> GeneratePdfFileAsync(DataSet dataSet);
    }
}
