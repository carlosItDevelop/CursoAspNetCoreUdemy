using System.Collections.Generic;
using System.Security.Claims;

namespace Cooperchip.ITDeveloper.Domain.Interfaces.Helpers
{
    public interface IUserInAllLayer
    {
        IDictionary<string, string> DictionaryOfClaimss();
        IEnumerable<Claim> LisOfClaims();
    }
}
