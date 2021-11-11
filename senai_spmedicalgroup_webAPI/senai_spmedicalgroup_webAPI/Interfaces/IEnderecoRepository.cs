using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IEnderecoRepository
    {
        List<Endereco> ListarTodos();

        Endereco BuscarPorID(int idEndereco);

        void Cadastrar(Endereco novoEndereco);

        void AtualizarURL(int idEndereco, Endereco enderecoAtualizado);

        void Remover(int idEndereco);
    }
}
