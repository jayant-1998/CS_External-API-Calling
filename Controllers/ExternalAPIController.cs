using External_API_Calling.Models.ResponseViewModels;
using External_API_Calling.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace External_API_Calling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalAPIController : ControllerBase
    {
        private readonly IDataManipulatorService _dataManipulator;
        public ExternalAPIController(IServiceProvider serviceProvider)
        {
            _dataManipulator = serviceProvider.GetRequiredService<IDataManipulatorService>();
        }
        [HttpGet("get-all-centers")]
        public async Task<IActionResult> GetAllCenters()
        {
            try
            {
                var result = await _dataManipulator.GetAllCentersAsync();

                return Ok(new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "Success",
                    Body = result
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                });
            }
        }
        [HttpGet("filters")]
        public async Task<IActionResult> Filters(string? place, string? state)
        {
            try
            {
                var result = await _dataManipulator.CenterFilteringAsync(place, state);

                return Ok(new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "Success",
                    Body = result
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                });
            }
        }
        [HttpGet("sorting")]
        public async Task<IActionResult> Sorting(string? orderBy,string? Type)
        {
            try
            {
                if (string.IsNullOrEmpty(orderBy))
                {
                    orderBy = "asc";
                }
                if(string.IsNullOrEmpty(Type)) 
                {
                    Type = "name";
                }
                var result = await _dataManipulator.SortingAsync(Type, orderBy);

                return Ok(new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "Success",
                    Body = result
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                });
            }
        }
        [HttpGet("paging")]
        public async Task<IActionResult> Paging(int page)
        {
            try
            {
                if (page == 0)
                {
                    page = 1;
                }
                var result = await _dataManipulator.PagingAsync(page);

                return Ok(new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "Success",
                    Body = result
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                });
            }
        }
    }
}