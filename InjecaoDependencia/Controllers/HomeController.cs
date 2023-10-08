using InjecaoDependencia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InjecaoDependencia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOperacao _operacao;
        private readonly IServiceProvider _provider;

        public HomeController(IOperacao operacao, IServiceProvider provider)
        {
            _operacao = operacao;
            _provider = provider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Construtor")]
        public IActionResult Construtor()
        {
            return Ok(_operacao.Id);
        }

        [HttpGet("Anotacao")]
        public IActionResult Anotacao([FromServices] IOperacao operacao)
        {
            return Ok(operacao.Id);
        }

        [HttpGet("Provider")]
        public IActionResult Provider()
        {
            return Ok(_provider.GetRequiredService<IOperacao>());
        }

    }
}