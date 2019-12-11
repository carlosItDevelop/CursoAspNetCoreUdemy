using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Cooperchip.ITDeveloper.Mvc.Extentions.ViewComponents.Helpers
{
    public class ContadorEstadoPaciente
    {
        public int Parcial { get; set; }
        public string Percentual { get; set; }
        public string ClassContainer { get; set; }
        public string Titulo { get; set; }
        public decimal Progress { get; set; }
        public string IconeLg { get; set; }
        public string IconeSm { get; set; }
    }
}
