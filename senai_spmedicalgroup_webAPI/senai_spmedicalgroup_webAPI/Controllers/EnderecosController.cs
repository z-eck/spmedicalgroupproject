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
    public class EnderecosController : ControllerBase
    {
        private IEnderecoRepository EndrcRepository { get; set; }
        public EnderecosController()
        {
            EndrcRepository = new EnderecoRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EndrcRepository.ListarTodos());
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(EndrcRepository.BuscarPorID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Endereco novoEndereco)
        {
            EndrcRepository.Cadastrar(novoEndereco);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, Endereco enderecoAtualizado)
        {
            EndrcRepository.AtualizarURL(id, enderecoAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EndrcRepository.Remover(id);

            return StatusCode(204);
        }
    }
}
