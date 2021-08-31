using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Response;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infraestructure.Interfaces;
using SocialMedia.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public PostController(IPostService postService, IMapper mapper, IUriService uriService)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK,Type = typeof(ApiResponse<IEnumerable<PublicacionDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PublicacionDTO>>))]
        public IActionResult GetPosts([FromQuery]PostQueryFilter filter)
        {
            var posts = _postService.GetPosts(filter);
            var postsDTO = _mapper.Map<IEnumerable<PublicacionDTO>>(posts);
            var metaData = new Metadata
            {
                TotalCount = posts.TotalCount,
                PageSize = posts.PageSize,
                CurrentPage = posts.CurrentPage,
                TotalPages = posts.TotalPages,
                HasNextPage = posts.HasNextPage,
                HasPreviousPage = posts.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUrl(filter,Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUrl(filter, Url.RouteUrl(nameof(GetPosts))).ToString()
            };
            var response = new ApiResponse<IEnumerable<PublicacionDTO>>(postsDTO)
            {
                Meta = metaData
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            var postDTO = _mapper.Map<PublicacionDTO>(post);
            var response = new ApiResponse<PublicacionDTO>(postDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PublicacionDTO postDTO)
        {
            var post = _mapper.Map<Publicacion>(postDTO);
            await _postService.InsertPost(post);
            postDTO = _mapper.Map<PublicacionDTO>(post);
            var response = new ApiResponse<PublicacionDTO>(postDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PublicacionDTO postDTO)
        {
            var post = _mapper.Map<Publicacion>(postDTO);
            post.Id = postDTO.Id;
            var res = await _postService.UpdatePost(post);
            var response = new ApiResponse<bool>(res);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var res = await _postService.DeletePost(id);
            var response = new ApiResponse<bool>(res);
            return Ok(response);
        }

    }
}
