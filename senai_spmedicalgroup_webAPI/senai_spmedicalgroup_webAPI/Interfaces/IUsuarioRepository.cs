using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        Usuario BuscarPorID(int idUsuario);

        void Cadastrar(Usuario novoUsuario);

        void AtualizarURL(int idUsuario, Usuario usuarioAtualizado);

        void Remover(int idUsuario);

        Usuario Login(string email, string senha);
    }
}
