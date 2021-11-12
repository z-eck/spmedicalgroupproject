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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository EspclddRepository { get; set; }
        public EspecialidadesController()
        {
            EspclddRepository = new EspecialidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EspclddRepository.ListarTodos());
        }

        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(EspclddRepository.BuscarPorID(id));
        }

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Especialidade novaEspecialidade)
        {
            EspclddRepository.Cadastrar(novaEspecialidade);

            return StatusCode(201);
        }

        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, Especialidade especialidadeAtualizada)
        {
            EspclddRepository.AtualizarURL(id, especialidadeAtualizada);

            return StatusCode(204);
        }

        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EspclddRepository.Remover(id);

            return StatusCode(204);
        }
    }
}
