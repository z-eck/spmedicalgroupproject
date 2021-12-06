using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AgendamentosController : ControllerBase
    {
        private IAgendamentoRepository AgndmntRepository { get; set; }
        public AgendamentosController()
        {
            AgndmntRepository = new AgendamentoRepository();
        }

        //[Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(AgndmntRepository.ListarTodos());
        }

        //[Authorize(Roles = "1")]
        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(AgndmntRepository.BuscarPorID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Agendamento novoAgendamento)
        {
            AgndmntRepository.Cadastrar(novoAgendamento);

            return StatusCode(201);
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, Agendamento agendamentoAtualizado)
        {
            AgndmntRepository.AtualizarURL(id, agendamentoAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            AgndmntRepository.Remover(id);

            return StatusCode(204);
        }
    }
}
