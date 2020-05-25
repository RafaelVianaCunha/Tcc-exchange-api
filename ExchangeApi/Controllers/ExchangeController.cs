using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers
{
    public class ExchangeController : Controller
    {
        [HttpPost]
        public Task<IActionResult> Create()
        {
            return null;
        }
    }
}