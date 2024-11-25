using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Custom
{
    public class Utilidades
    {

        private readonly   IConfiguration _configuration; //accedemos a la info de appsettings
        public  Utilidades(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string encriptarSHA256(string texto) //metodo para usar la encriptacion
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //computar el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                //convertir el array de bytes en un string 

                StringBuilder builder1 = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder1.Append(bytes[i].ToString("x2"));
                }

                return builder1.ToString();

            }
        }



        public string generarJWT(Usuario modelo)
        {
            //crear la info del uusario para el token 
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email, modelo.Correo!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //crear detalle del token 
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);

        }

    }
}
