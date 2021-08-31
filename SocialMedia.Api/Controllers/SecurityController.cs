using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Response;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumerations;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordHash _passwordHash;
        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordHash passwordHash)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordHash = passwordHash;
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(SecurityDTO securityDTO)
        {
            var security = _mapper.Map<Security>(securityDTO);

            security.Password = _passwordHash.Hash(security.Password);

            await _securityService.RegisterUser(security);
            securityDTO = _mapper.Map<SecurityDTO>(security);
            var response = new ApiResponse<SecurityDTO>(securityDTO);
            return Ok(response);
        }

    }
}
