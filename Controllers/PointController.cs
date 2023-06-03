using Microsoft.AspNetCore.Mvc;
using Lasmart.Models;
using Lasmart.Services;

namespace Lasmart.Controllers
{
    [Route("api/points")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private PointService pointService;
        public PointController()
        {
            pointService = new PointService();
        }
        [Route("create")]
        [HttpPost]
        public OkResult CreatePoint([FromBody] Point point)
        {
            pointService.CreatePoint(point);
            return Ok();
        }
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAllPoints()
        {
            var points = pointService.GetAllPoins();
            return Ok(points);
        }
        [Route("setRemowalTime/{pointID}")]
        [HttpPut]
        public OkResult SetRemowalTime([FromRoute] Guid pointId)
        {
            pointService.SetRemovalTime(pointId);
            return Ok();
        }
    }
}
