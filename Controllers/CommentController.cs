using Lasmart.Models;
using Lasmart.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lasmart.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : Controller
    {
        private PointService pointService;
        public CommentController()
        {
            pointService = new PointService();
        }
        [Route("create")]
        [HttpPost]
        public OkResult CreateComment([FromBody] Comment comment)
        {
            pointService.CreateComment(comment);
            return Ok();
        }
        [Route("getCommentsByPoint/{pointId}")]
        [HttpGet]
        public IActionResult GetCommentsByPoint([FromRoute] Guid pointId)
        {
            var comments = pointService.GetCommentsByPoint(pointId);
            return Ok(comments);
        }
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = pointService.GetAllComments();
            return Ok(comments);
        }
        //[Route("getAll")]
        //[HttpGet]
        //public IActionResult GetAllComments() {}
    }
}
