using External_API_Calling.DAL.Repositories.Interfaces;
using External_API_Calling.Extensions;
using External_API_Calling.Models.ResponseViewModels;

namespace External_API_Calling.DAL.Repositories.Implementations
{
    public class GettingDataRepo : IGettingDataRepo
    {
        private readonly IConfiguration _configuration;
        public GettingDataRepo(IServiceProvider serviceProvider)
        {
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
        }
        public async Task<Center> GetALLCentersAsync()
        {
            string requestUrl = _configuration["ISRO:URL"];
            return await requestUrl.HttpCall<Center>(HttpMethod.Get,null);
        }
    }
}

