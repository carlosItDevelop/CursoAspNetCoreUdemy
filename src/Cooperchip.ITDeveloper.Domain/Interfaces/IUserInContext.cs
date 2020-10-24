using System;
using System.Collections.Generic;
using System.Security.Claims;
namespace Cooperchip.ITDeveloper.Domain.Interfaces
{
    public interface IUserInContext<TKey>
    {
        string Name { get; }
        TKey GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
        string GetUserApelido();
        string GetUserNomeCompleto();
        string GetUserDataNascimento();
        string GetUserImgProfilePath();
    }
}
