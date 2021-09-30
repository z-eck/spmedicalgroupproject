using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IAgendamentoRepository
    {
        List<Agendamento> ListarTodos(int idAgendamento);

        Agendamento BuscarPorID(int idAgendamento);

        void Cadastrar(Agendamento novoAgendamento);

        void AtualizarURL(int idAgendamento, Agendamento agendamentoAtualizado);

        void Remover(int idAgendamento);
    }
}
