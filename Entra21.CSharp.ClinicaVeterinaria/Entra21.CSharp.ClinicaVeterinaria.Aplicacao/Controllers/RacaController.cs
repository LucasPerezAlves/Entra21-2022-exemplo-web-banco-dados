using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    //Dois pontos herança (mais pra frente)
    public class RacaController : Controller
    {
        private readonly IRacaServico _racaServico;
        private readonly List<string> _especies;

        //Construtor: Objetivo construir o objeto de RacaController, com o minimo
        //necessários para o funcionamento correto
        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
            //racaServico.Cadastrar(nome, especie);
        }
        /// <summary>
        /// Endpoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>

        [HttpGet("/raca")]

        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            //passar informação do C# para o HTML
            ViewBag.Racas = racas;

            return View("Index");
        }

        [HttpGet("/raca/cadastrar")]
        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();

            ViewBag.Especies = especies;

            var racaCadastrarViewModel = new RacaCadastrarViewModel();

            return View();
        }

        [HttpPost("/raca/cadastrar")]
        public IActionResult Cadastrar(
            [FromForm] RacaCadastrarViewModel racaCadastrar)
        {
            //Valida o parâmetro recebido a Action se é valida
            //if(ModelState == false) = mesma coisa que colocar um exclamação no início
            if (!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();
            }
            _racaServico.Cadastrar(racaCadastrar);

            return RedirectToAction("index");
        }

        [HttpGet("/raca/apagar")]
        //https://localhost:porta/raca/apagar?id=4
        public IActionResult Apagar([FromQuery] int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("index");
        }

        [HttpGet("/raca/editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaServico.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especies = especies;

            return View("Editar");
        }

        [HttpPost("/raca/editar")]
        public IActionResult Editar(
            [FromForm] RacaEditarViewModel racaEditarViewModel)
        {
            _racaServico.Editar(racaEditarViewModel);

            return RedirectToAction("Index");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>()
                            .OrderBy(x => x)
                            .ToList();
        }
    }
}
