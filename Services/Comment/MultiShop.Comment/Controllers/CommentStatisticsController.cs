using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentStatisticsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentStatisticsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            int values = await _context.UserComments.CountAsync();

            return Ok(values);
        }
    }
}
