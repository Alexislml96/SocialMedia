using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Interfaces
{
    public interface IPasswordHash
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }
}
