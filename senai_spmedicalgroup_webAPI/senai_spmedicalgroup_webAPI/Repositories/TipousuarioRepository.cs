using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class TipousuarioRepository : ITipousuarioRepository
    {
        readonly SPMEDICALGROUPContext context = new();

        public Tipousuario BuscarPorID(int idTipoUsuario)
        {
            return context.Tipousuarios
                .Select(t => new Tipousuario
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    DescricaoTipoUsuario = t.DescricaoTipoUsuario,
                })
                .FirstOrDefault(t => t.IdTipoUsuario == idTipoUsuario);
        }

        public List<Tipousuario> ListarTodos(int idTipoUsuario)
        {
            return context.Tipousuarios
                .Select(t => new Tipousuario
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    DescricaoTipoUsuario = t.DescricaoTipoUsuario,
                })
                .ToList();
        }
    }
}
