using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();

        Medico BuscarPorID(int idMedico);

        void Cadastrar(Medico novoMedico);

        void AtualizarURL(int idMedico, Medico medicoAtualizado);

        void Remover(int idMedico);
    }
}
