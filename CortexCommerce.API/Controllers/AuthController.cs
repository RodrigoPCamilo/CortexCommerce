using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CortexCommerce.API.Models.Login.Requisicao;
using CortexCommerce.Aplicacao.DTOs.Login;
using CortexCommerce.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CortexCommerce.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAplicacao _authService;
        public AuthController(IAuthAplicacao authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _authService.LoginAsync(new LoginDto
            {
                Email = request.Email,
                Senha = request.Senha
            });

            return Ok(new { Token = token });
        }
    }
}
    