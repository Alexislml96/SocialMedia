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
    public class PostRepository : BaseRepository<Publicacion>, IPostRepository
    {
        public PostRepository(BasePruebaHDContext context) : base(context) { }
        public async Task<IEnumerable<Publicacion>> GetPostsByUser(int userID)
        {
            return await _entities.Where(x => x.IdUsuario == userID).ToListAsync();
        }
    }
}
