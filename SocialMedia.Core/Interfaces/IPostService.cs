using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        PagedList<Publicacion> GetPosts(PostQueryFilter filter);
        Task<Publicacion> GetPost(int id);
        Task InsertPost(Publicacion post);
        Task<bool> UpdatePost(Publicacion post);
        Task<bool> DeletePost(int id);
    }
}