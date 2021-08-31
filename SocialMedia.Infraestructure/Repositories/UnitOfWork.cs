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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BasePruebaHDContext _context;
        private readonly IPostRepository _postRepository;
        private readonly IRepositoryBase<Usuario> _userRepository;
        private readonly IRepositoryBase<Comentario> _commentRepository;
        private readonly SecurityRepository _securityRepository;
        public UnitOfWork(BasePruebaHDContext context)
        {
            _context = context;
        }
        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

        public IRepositoryBase<Usuario> UserRepository => _userRepository ?? new BaseRepository<Usuario>(_context);

        public IRepositoryBase<Comentario> CommentRepository => _commentRepository ?? new BaseRepository<Comentario>(_context);

        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
