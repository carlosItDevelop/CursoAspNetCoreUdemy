using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class CodePageController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CodigoPagina> listaCodPage = new List<CodigoPagina>();
            foreach (EncodingInfo encInfo in Encoding.GetEncodings())
            {
                Encoding e = encInfo.GetEncoding(); // Não estou usando ainda               
                listaCodPage.Add(new CodigoPagina 
                { 
                    Code = encInfo.CodePage,
                    Name = encInfo.Name,
                    DisplayName = encInfo.DisplayName,
                    WebName = encInfo.GetEncoding().WebName
                });
            }
            return View(listaCodPage.AsEnumerable());
        }
    }

    public class CodigoPagina
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string WebName { get; set; }
    }

}
