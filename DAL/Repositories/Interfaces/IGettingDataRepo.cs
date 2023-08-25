using External_API_Calling.Models.ResponseViewModels;

namespace External_API_Calling.DAL.Repositories.Interfaces
{
    public interface IGettingDataRepo
    {
        public Task<Center> GetALLCentersAsync();
    }
}
