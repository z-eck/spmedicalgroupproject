using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedicalgroup_webAPI.Domains;
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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository mdcRepository { get; set; }
        public MedicosController()
        {
            mdcRepository = new MedicoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(mdcRepository.ListarTodos());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{îd}")]
        public IActionResult BuscarID(int id)
        {
            return Ok(mdcRepository.BuscarPorID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            mdcRepository.Cadastrar(novoMedico);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AtualizarURL(int id, Medico medicoAtualizado)
        {
            mdcRepository.AtualizarURL(id, medicoAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            mdcRepository.Remover(id);

            return StatusCode(204);
        }
    }
}
