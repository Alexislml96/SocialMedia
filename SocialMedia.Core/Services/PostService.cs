using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Publicacion> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public PagedList<Publicacion> GetPosts(PostQueryFilter filter)
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            if (filter.UserID != null)
            {
                posts = posts.Where(x => x.IdUsuario == filter.UserID);
            }
            if (filter.Date != null)
            {
                posts = posts.Where(x => x.Fecha.ToShortDateString() == filter.Date?.ToShortDateString());
            }
            if (filter.Description != null)
            {
                posts = posts.Where(x => x.Descripcion.ToLower().Contains(filter.Description.ToLower()));
            }

            var pagedPosts = PagedList<Publicacion>.Create(posts, filter.PageNumber, filter.PageSize);

            return pagedPosts;
        }

        public async Task InsertPost(Publicacion post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.IdUsuario);
            if (user == null)
            {
                throw new BusinessException("User doesn't exists");
            }

            var userPost = await _unitOfWork.PostRepository.GetPostsByUser(post.IdUsuario);
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x=> x.Fecha).FirstOrDefault();
                if ((DateTime.Now - lastPost.Fecha).TotalDays < 7)
                {
                    throw new BusinessException("You are no able to post");
                }
            }

            if (post.Descripcion.Contains("Sexo"))
            {
                throw new BusinessException("Content not allowed");
            }

            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Publicacion post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }
    }
}
