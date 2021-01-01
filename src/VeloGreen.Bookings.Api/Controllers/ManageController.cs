using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeloGreen.Bookings.Api.Entities;
using VeloGreen.Bookings.Api.Handlers;
using VeloGreen.Bookings.Api.Mappers;

namespace VeloGreen.Bookings.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        private readonly IBookableHandler _bookableHandler;

        public ManageController(IBookableHandler bookableHandler)
        {
            _bookableHandler = bookableHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookable([FromBody] BookableCreateRequest createRequest)
        {
            await _bookableHandler.Create(BookableMapper.MapToBookable(createRequest));

            return Ok();
        }
    }
}
