using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        readonly SPMEDICALGROUPContext context = new();

        public void AtualizarURL(int idAgendamento, Agendamento agendamentoAtualizado)
        {
            Agendamento agendamentoBuscado = context.Agendamentos.Find(idAgendamento);

            if (agendamentoAtualizado.IdPacienteNavigation.NomePaciente != null || agendamentoAtualizado.IdMedicoNavigation.NomeMedico != null || agendamentoAtualizado.IdMedicoNavigation.SobrenomeMedico != null || agendamentoAtualizado.DatahoraConsulta != null || agendamentoAtualizado.IdSituacaoNavigation.Descricao != null)
            {
                agendamentoBuscado.IdPacienteNavigation.NomePaciente = agendamentoAtualizado.IdPacienteNavigation.NomePaciente;
                agendamentoBuscado.IdMedicoNavigation.NomeMedico = agendamentoAtualizado.IdMedicoNavigation.NomeMedico;
                agendamentoBuscado.IdMedicoNavigation.SobrenomeMedico = agendamentoAtualizado.IdMedicoNavigation.SobrenomeMedico;
                agendamentoBuscado.DatahoraConsulta = agendamentoAtualizado.DatahoraConsulta;
                agendamentoBuscado.IdSituacaoNavigation.Descricao = agendamentoAtualizado.IdSituacaoNavigation.Descricao;

                context.Agendamentos.Update(agendamentoBuscado);

                context.SaveChanges();
            }
        }

        public Agendamento BuscarPorID(int idAgendamento)
        {
            return context.Agendamentos
                .Select(a => new Agendamento
                {
                    IdAgendamento = a.IdAgendamento,
                    IdPacienteNavigation = new Paciente()
                    {
                        NomePaciente = a.IdPacienteNavigation.NomePaciente,
                    },
                    IdMedicoNavigation = new Medico()
                    {
                        NomeMedico = a.IdMedicoNavigation.NomeMedico,
                        SobrenomeMedico = a.IdMedicoNavigation.SobrenomeMedico,
                    },
                    DatahoraConsulta = a.DatahoraConsulta,
                    IdSituacaoNavigation = new Situacao()
                    {
                        Descricao = a.IdSituacaoNavigation.Descricao
                    },
                })
                .FirstOrDefault(a => a.IdAgendamento == idAgendamento);
        }

        public void Cadastrar(Agendamento novoAgendamento)
        {
            context.Agendamentos.Add(novoAgendamento);

            context.SaveChanges();
        }

        public List<Agendamento> ListarTodos(int idAgendamento)
        {
            return context.Agendamentos
                .Select(a => new Agendamento
                {
                    IdAgendamento = a.IdAgendamento,
                    IdPacienteNavigation = new Paciente()
                    {
                        NomePaciente = a.IdPacienteNavigation.NomePaciente,
                    },
                    IdMedicoNavigation = new Medico()
                    {
                        NomeMedico = a.IdMedicoNavigation.NomeMedico,
                        SobrenomeMedico = a.IdMedicoNavigation.SobrenomeMedico,
                    },
                    DatahoraConsulta = a.DatahoraConsulta,
                    IdSituacaoNavigation = new Situacao()
                    {
                        Descricao = a.IdSituacaoNavigation.Descricao
                    },
                })
                .OrderBy(a => a.DatahoraConsulta)
                .ToList();
        }

        public void Remover(int idAgendamento)
        {
            context.Agendamentos.Remove(BuscarPorID(idAgendamento));

            context.SaveChanges();
        }
    }
}
