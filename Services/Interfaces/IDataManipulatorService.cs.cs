using External_API_Calling.Models.ResponseViewModels;

namespace External_API_Calling.Services.Interfaces
{
    public interface IDataManipulatorService
    {
        public Task<Center> GetAllCentersAsync();
        public Task<Center> CenterFilteringAsync(string? place ,string? state);
        public Task<Center> SortingAsync(string? orderBY, string? type);
        public Task<List<CenterList>> PagingAsync(int page);
    }
}
