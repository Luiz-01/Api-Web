ççusing Hanssens.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Api.Authenticate;
using Weather_Station.Api.Models;
using Weather_Station.Application.Interface;
using Weather_Station.Domain.Entities;

namespace Weather_Station.Api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] LoginModel usuario, [FromServices] TokenConfiguration tokenConfiguration)
        {
            tb_usu_usuario buscaUsuario = _serviceBase.GetByFilter(x => x.usu_c_usuario == usuario.Usuario && x.usu_c_senha == usuario.Senha).FirstOrDefault();

            if (buscaUsuario != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(buscaUsuario.usu_n_codigo.ToString(), "id"));

                DateTime dataCriacao = DateTime.Now;
                DateTime dtExpira = dataCriacao + TimeSpan.FromSeconds(tokenConfiguration.Second);
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Key));
                var Credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Jwt = new JwtSecurityTokenHandler();
                var securityToken = Jwt.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Issuer = tokenConfiguration.Issuer,
                    Audience = tokenConfiguration.Audience,
                    SigningCredentials = Credentials,
                    Expires = dtExpira,
                    NotBefore = dataCriacao,
                    Subject = identity
                });

                var token = Jwt.WriteToken(securityToken);
                var storage = new LocalStorage();
                storage.Load();
                UserToken userToken = new UserToken();
                userToken.id = buscaUsuario.usu_n_codigo.ToString();
                userToken.token = token;
                storage.Store<UserToken>(buscaUsuario.usu_n_codigo.ToString(), userToken);
                storage.Persist();

                return new
                {
                    authenticate = true,
                    message = "Sucesso",
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dtExpira.ToString("yyyy-MM-dd HH:mm:ss"),
                    accesToken = token
                };
            }

            else
            {
                return new
                {
                    authenticate = false,
                    message = "Usuário Inválido"
                };
            }
        }
    }
}
