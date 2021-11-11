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
    [Authorize(Roles = "1")]
    public class TipousuariosController : ControllerBase
    {
        private ITipousuarioRepository tpsrRepository { get; set; }
        public TipousuariosController()
        {
            tpsrRepository = new TipousuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(tpsrRepository.ListarTodos());
        }

        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(tpsrRepository.BuscarPorID(id));
        }
    }
}
