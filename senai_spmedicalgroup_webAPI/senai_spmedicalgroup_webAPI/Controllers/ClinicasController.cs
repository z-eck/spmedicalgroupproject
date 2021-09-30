using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Interfaces;
using senai_spmedicalgroup_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository clncRepository { get; set; }
        public ClinicasController()
        {
            clncRepository = new ClinicaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(clncRepository.ListarTodos());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(clncRepository.BuscarPorID(id));
        }
    }
}
