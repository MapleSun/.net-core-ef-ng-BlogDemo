using BlogDemo.core.Entities;
using BlogDemo.core.Interfaces;
using BlogDemo.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Api.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IPostRepository postReporsitory, IUnitOfWork unitOfWork)
        {

            _postRepository = postReporsitory;
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postRepository.GetAllPostsAsync();

            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            var newPost = new Post
            {
                Author = "admin",
                Body = "1231231412312312312",
                Title = "Title A",
                LastModified = DateTime.Now
            };

            _postRepository.AddPost(newPost);

            await _unitOfWork.SaveAsync();

            return Ok();
        }
       
    }
}
