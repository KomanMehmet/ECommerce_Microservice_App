using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);

            _context.SaveChanges();

            return Ok("Comment created successfully.");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);

            _context.SaveChanges();

            return Ok("Comment updated successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _context.UserComments.Find(id);

            _context.UserComments.Remove(value);

            _context.SaveChanges();

            return Ok("Comment deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _context.UserComments.Find(id);

            return Ok(value);
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _context.UserComments.Where(x => x.ProductID == id).ToList();

            return Ok(value);
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int activeCommentCount = _context.UserComments.Count(x => x.Status == true);

            return Ok(activeCommentCount);
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            int passiveCommentCount = _context.UserComments.Count(x => x.Status == false);

            return Ok(passiveCommentCount);
        }

        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            int totalCommentCount = _context.UserComments.Count();

            return Ok(totalCommentCount);
        }
    }
}
