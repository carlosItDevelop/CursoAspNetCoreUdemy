using Cooperchip.ITDeveloper.CrossCutting.Extensions;
using Cooperchip.ITDeveloper.Domain.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Cooperchip.ITDeveloper.CrossCutting.Helpers
{
    public class AspNetUser : IUserInContext
    {
        private readonly IHttpContextAccessor _accessor;
        ClaimsPrincipal _user;

        public AspNetUser(IHttpContextAccessor accessor){ 
            _accessor = accessor;
            _user = _accessor.HttpContext.User;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid GetUserId() { return IsAuthenticated() ? Guid.Parse(_user.GetUserId()) : Guid.Empty; }
        
        public string GetUserEmail() { 
            return IsAuthenticated() ? _user.GetUserEmail() : ""; 
        }

        public string GetUserApelido() { return IsAuthenticated() ? _user.GetUserApelido() : "";}
        public string GetUserDataNascimento() { return IsAuthenticated() ? _user.GetUserDataNascimento() : ""; }
        public string GetUserImgProfilePath() { return IsAuthenticated() ? _user.GetUserImgProfilePath() : ""; }
        public string GetUserNomeCompleto() { return IsAuthenticated() ? _user.GetUserNomeCompleto() : ""; }
        public IEnumerable<Claim> GetClaimsIdentity() { return _user.Claims; }
        
        public bool IsInRole(string role) { return _user.IsInRole(role); }
        public bool IsAuthenticated() { return _user.Identity.IsAuthenticated; }

    }
}
