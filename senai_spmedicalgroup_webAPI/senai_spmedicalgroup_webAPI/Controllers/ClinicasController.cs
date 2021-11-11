using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1, 2")]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository clncRepository { get; set; }
        public ClinicasController()
        {
            clncRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(clncRepository.ListarTodos());
        }

        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(clncRepository.BuscarPorID(id));
        }
    }
}
