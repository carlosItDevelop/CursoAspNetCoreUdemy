using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.Middlewares
{
    public static class UseAddUsersAndRolesExtension
    {
        public static IApplicationBuilder UseAddUserAndRoles(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DefaultUsersAndRolesMiddeware>();
        }
    }
}
