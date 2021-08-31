using SocialMedia.Core.QueryFilters;
using System;

namespace SocialMedia.Infraestructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUrl(PostQueryFilter filter, string actionUrl);
    }
}