using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentService commentService;
        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: api/Comments
        [HttpGet]
        public IEnumerable<CommentGetModel> Get([FromQuery]string filter)
        {
            return commentService.GetAll(filter);
        }

        // GET: api/Comments/5
        [HttpGet("{id}", Name = "GetComments")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comments
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
