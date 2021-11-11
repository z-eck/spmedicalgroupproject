using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private IUsuarioRepository srRepository { get; set; }

            public LoginController()
            {
                srRepository = new UsuarioRepository();
            }

            [HttpPost]
            public IActionResult Login(Usuario login)
            {
                Usuario usuarioBuscado = srRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado.Email == null)
                {
                    return NotFound("Email inválido!");
                }
                if (usuarioBuscado.Senha == null)
                {
                    return NotFound("Senha inválida!");
                }

                var minhasClaims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("13Ma01ECAErOl21S"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer: "senai_spmedicalgroup_webAPI",
                    audience: "senai_spmedicalgroup_webAPI",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(59),
                    signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
        }
    }
}
