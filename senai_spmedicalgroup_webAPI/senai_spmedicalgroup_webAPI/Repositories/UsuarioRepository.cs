using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly SPMEDICALGROUPContext context = new();
        public void AtualizarURL(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = context.Usuarios.Find(idUsuario);

            if (usuarioAtualizado.Email != null || usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;

                context.Usuarios.Update(usuarioBuscado);

                context.SaveChanges();
            }
        }

        public Usuario BuscarPorID(int idUsuario)
        {
            return context.Usuarios
                .Select(u => new Usuario
                {
                    IdTipoUsuarioNavigation = new Tipousuario
                    {
                        DescricaoTipoUsuario = u.IdTipoUsuarioNavigation.DescricaoTipoUsuario,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        NomeMedico = u.IdMedicoNavigation.NomeMedico,
                        SobrenomeMedico = u.IdMedicoNavigation.SobrenomeMedico,
                    },
                    IdPacienteNavigation = new Paciente
                    {
                        NomePaciente = u.IdPacienteNavigation.NomePaciente,
                    },
                    Email = u.Email,
                })
                .FirstOrDefault(u => u.IdUsuario == idUsuario);
                
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            context.Usuarios.Add(novoUsuario);

            context.SaveChanges();

        }

        public List<Usuario> ListarTodos()
        {
            return context.Usuarios
                .Select(u => new Usuario
                {
                    IdTipoUsuarioNavigation = new Tipousuario
                    {
                        DescricaoTipoUsuario = u.IdTipoUsuarioNavigation.DescricaoTipoUsuario,
                    },
                    IdMedicoNavigation = new Medico
                    {
                        NomeMedico = u.IdMedicoNavigation.NomeMedico,
                        SobrenomeMedico = u.IdMedicoNavigation.SobrenomeMedico,
                    },
                    IdPacienteNavigation = new Paciente
                    {
                        NomePaciente = u.IdPacienteNavigation.NomePaciente,
                    },
                    Email = u.Email,
                })
                .ToList();
        }

        public void Remover(int idUsuario)
        {
            context.Usuarios.Remove(BuscarPorID(idUsuario));

            context.SaveChanges();
        }

        public Usuario Login(string email, string senha)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email == email || u.Senha == senha);
        }
    }
}
