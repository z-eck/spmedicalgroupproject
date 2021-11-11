using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IAgendamentoRepository
    {
        /// <summary>
        /// Realiza uma listagem dos agendamentos
        /// </summary>
        /// <returns>Devolve uma lista dos agendamentos</returns>
        List<Agendamento> ListarTodos();

        /// <summary>
        /// Busca um agendamento pelo ID
        /// </summary>
        /// <param name="idAgendamento">É o parâmetro que será informado para qual agendamento deverá ser buscado</param>
        /// <returns>Um único agendamento por vez</returns>
        Agendamento BuscarPorID(int idAgendamento);

        /// <summary>
        /// Cadastra um novo agendamento
        /// </summary>
        /// <param name="novoAgendamento">É o parâmetro que será informado quais são as informações para serem inseridas no cadastro</param>
        void Cadastrar(Agendamento novoAgendamento);

        /// <summary>
        /// Atualiza um agendamento
        /// </summary>
        /// <param name="idAgendamento">É o parâmetro que será informado para saber qual agendamento será atualizado pela URL</param>
        /// <param name="agendamentoAtualizado">É o parâmetro que será usado para atualizar as informações inseridas de um agendamento existente</param>
        void AtualizarURL(int idAgendamento, Agendamento agendamentoAtualizado);

        /// <summary>
        /// Remove um agendamento
        /// </summary>
        /// <param name="idAgendamento">É o parâmetro que será usado para informar qual o agendamento que deverá ser excluído</param>
        void Remover(int idAgendamento);
    }
}
