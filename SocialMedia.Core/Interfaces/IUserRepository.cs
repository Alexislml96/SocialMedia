using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario> GetUser(int id);
        Task<IEnumerable<Usuario>> GetUsers();
    }
}