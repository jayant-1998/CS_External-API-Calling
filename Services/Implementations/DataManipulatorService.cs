using External_API_Calling.DAL.Repositories.Interfaces;
using External_API_Calling.Models.ResponseViewModels;
using External_API_Calling.Services.Interfaces;

namespace External_API_Calling.Services.Implementations
{
    public class DataManipulatorService : IDataManipulatorService
    {
        private readonly IGettingDataRepo gettingData;
        public DataManipulatorService(IServiceProvider serviceProvider)
        {
            gettingData = serviceProvider.GetRequiredService<IGettingDataRepo>();
        }

        public async Task<Center> CenterFilteringAsync(string? place, string? state)
        {
            var result = await gettingData.GetALLCentersAsync();

            if (state != null)
            {
                result.Centres = result.Centres.Where(c => c.State == state).ToList();
            }
            if (place != null)
            {
                result.Centres = result.Centres.Where(c => c.Place == place).ToList();
            }
            return result;
        }

        public Task<Center> GetAllCentersAsync()
        {
            return gettingData.GetALLCentersAsync();
        }

        public async Task<List<CenterList>> PagingAsync(int pageNumber)
        {
            var result = await gettingData.GetALLCentersAsync();

            int itemsPerPage = 10;
            int startIndex = (pageNumber - 1) * itemsPerPage;

            List<CenterList> page = result.Centres.Skip(startIndex).Take(itemsPerPage).ToList();
            return page;
        }

        public async Task<Center> SortingAsync(string type, string orderBy)
        {
            var result = await gettingData.GetALLCentersAsync();
            orderBy = orderBy.ToLower();
            switch (type.ToLower())
            {
                case "id":
                    result.Centres = orderBy == "desc" ? result.Centres.OrderByDescending(r => r.Id).ToList() : result.Centres.OrderBy(r => r.Id).ToList();
                    break;
                case "name":
                    result.Centres = orderBy == "desc" ? result.Centres.OrderByDescending(r => r.Name).ToList() : result.Centres.OrderBy(r => r.Name).ToList();
                    break;
                case "place":
                    result.Centres = orderBy == "desc" ? result.Centres.OrderByDescending(r => r.Place).ToList() : result.Centres.OrderBy(r => r.Place).ToList();
                    break;
                case "state":
                    result.Centres = orderBy == "desc" ? result.Centres.OrderByDescending(r => r.State).ToList() : result.Centres.OrderBy(r => r.State).ToList();
                    break;
            }
            return result;
        }
    }
}
