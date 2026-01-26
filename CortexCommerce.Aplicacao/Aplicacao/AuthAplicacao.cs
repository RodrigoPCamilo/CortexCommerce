using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Login;
using CortexCommerce.Aplicacao.Interfaces;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CortexCommerce.Aplicacao.Aplicacao
{
    public class AuthAplicacao : IAuthAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IConfiguration _configuration;

        public AuthAplicacao(
            IUsuarioRepositorio usuarioRepositorio,
            IConfiguration configuration)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDto dto)
        {
            var usuario = await _usuarioRepositorio.ObterPorEmailAsync(dto.Email);

            if (usuario == null || !usuario.ValidarSenha(dto.Senha))
                throw new UnauthorizedAccessException("Email ou senha inválidos.");

            var expiraEm = DateTime.UtcNow.AddHours(
                int.Parse(_configuration["Jwt:ExpireHours"]!)
            );

            var token = GerarToken(usuario, expiraEm);

            return new AuthResponseDTO
            {
                Token = token,
                ExpiraEm = expiraEm,
                Email = usuario.Email,
                Id = usuario.Id
            };
        }

        private string GerarToken(Usuario usuario, DateTime expiraEm)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var credenciais = new SigningCredentials(
                chave,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiraEm,
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
