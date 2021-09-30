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
    [Authorize]
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository pcntRepository { get; set; }
        public PacientesController()
        {
            pcntRepository = new PacienteRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(pcntRepository.ListarTodos());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(pcntRepository.BuscarPorID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            pcntRepository.Cadastrar(novoPaciente);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, Paciente pacienteAtualizado)
        {
            pcntRepository.AtualizarURL(id, pacienteAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            pcntRepository.Remover(id);

            return StatusCode(204);
        }
    }
}
