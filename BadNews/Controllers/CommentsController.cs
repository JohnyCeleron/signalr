using System;
using System.Linq;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsRepository commentsRepository;

        public CommentsController(CommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        // GET
        [HttpGet("api/news/{id}/comments")]
        public ActionResult<CommentsDto> GetCommentsForNews(Guid id)
        {
            var comments = commentsRepository.GetComments(id)
                .Select(c => new CommentDto
                {
                    User = c.User,
                    Value = c.Value
                }).ToList();

            var result = new CommentsDto
            {
                NewsId = id,
                Comments = comments
            };

            return Ok(result);
        }
    }
}