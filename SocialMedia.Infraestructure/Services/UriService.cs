using SocialMedia.Core.QueryFilters;
using SocialMedia.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUrl;
        public UriService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Uri GetPostPaginationUrl(PostQueryFilter filter, string actionUrl)
        {
            string baseU = $"{_baseUrl}{actionUrl}";
            return new Uri(baseU);
        }
    }
}
