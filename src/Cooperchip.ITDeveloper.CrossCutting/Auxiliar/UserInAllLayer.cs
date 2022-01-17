using Cooperchip.ITDeveloper.Domain.Interfaces.Helpers;
using System.Collections.Generic;
using System.Security.Claims;

namespace Cooperchip.ITDeveloper.CrossCutting.Auxiliar
{
    public class UserInAllLayer : IUserInAllLayer
    {
        private readonly IUserInContext _user;

        public UserInAllLayer(IUserInContext user)
        {
            this._user = user;
        }

        public IDictionary<string, string> DictionaryOfClaimss()
        {
            var email = "";

            IDictionary<string, string> minhasClaims = new Dictionary<string, string>();

            if (_user.IsAuthenticated())
            {
                // Já não consigo usar as 2 linhas abaixo;
                //var apelido = User.FindFirst(x => x.Type == "Apelido")?.Value;
                //email = User.FindFirst(e => e.Type == "Email")?.Value;

                minhasClaims.Add("Apelido", _user.GetUserApelido());
                minhasClaims.Add("Nome Completo", _user.GetUserNomeCompleto());
                minhasClaims.Add("Imagem do Perfil", _user.GetUserImgProfilePath());
                minhasClaims.Add("Id", _user.GetUserId().ToString());
                minhasClaims.Add("Nome", _user.Name);
                minhasClaims.Add("Email", _user.GetUserEmail());
                minhasClaims.Add("E Administrador", _user.IsInRole("Admin") ? "SIM" : "NÃO");

                var nome = minhasClaims["Nome"];
                email = minhasClaims["Email"];
                var EhAdministrador = minhasClaims["E Administrador"];
            }

            return minhasClaims;

        }

        public IEnumerable<Claim> LisOfClaims()
        {
            var claimsOfUser = _user.GetClaimsIdentity();
            return claimsOfUser;
        }
    }
}
