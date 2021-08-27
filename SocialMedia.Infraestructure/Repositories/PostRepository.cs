using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BasePruebaHDContext _context;
        public PostRepository(BasePruebaHDContext context)
        {
            _context = context;
        }
        public async Task <IEnumerable<Publicacion>> GetPosts()
        {
            var posts = await _context.Publicacions.ToListAsync();
            return posts;
        }

        public async Task<Publicacion> GetPost(int id)
        {
            var post = await _context.Publicacions.FirstOrDefaultAsync(x => x.IdPublicacion == id);
            return post;
        }

        public async Task InsertPost(Publicacion post)
        {
            _context.Publicacions.Add(post);
            await _context.SaveChangesAsync();
        }
    }
}
