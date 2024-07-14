using MarketDataAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketDataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null) return Ok(result.Value);
            if (result.IsSuccess && result.Value == null) return NotFound();
            return BadRequest(result.Error);
        }

        protected ActionResult HandlePagedResult<T>(PagedResult<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
            {
                Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(new
                {
                    result.CurrentPage,
                    result.PageSize,
                    result.TotalCount,
                    result.TotalPages
                }));
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null) return NotFound();
            return BadRequest(result.Error);
        }
    }
}
