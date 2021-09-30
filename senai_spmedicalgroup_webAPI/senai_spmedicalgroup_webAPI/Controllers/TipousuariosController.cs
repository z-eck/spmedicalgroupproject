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
    public class TipousuariosController : ControllerBase
    {
        private ITipousuarioRepository tpsrRepository { get; set; }
        public TipousuariosController()
        {
            tpsrRepository = new TipousuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(tpsrRepository.ListarTodos());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(tpsrRepository.BuscarPorID(id));
        }
    }
}
