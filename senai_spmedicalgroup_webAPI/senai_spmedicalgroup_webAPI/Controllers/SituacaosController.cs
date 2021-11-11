using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SituacaosController : ControllerBase
    {
        private ISituacaoRepository stcRepository { get; set; }
        public SituacaosController()
        {
            stcRepository = new SituacaoRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(stcRepository.ListarTodos());
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(stcRepository.BuscarPorID(id));
        }
    }
}
