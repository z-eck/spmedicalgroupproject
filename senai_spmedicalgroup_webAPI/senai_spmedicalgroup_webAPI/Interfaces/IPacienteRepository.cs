using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos(int idPaciente);

        Paciente BuscarPorID(int idPaciente);

        void Cadastrar(Paciente novoPaciente);

        void AtualizarURL(int idPaciente, Paciente pacienteAtualizado);

        void Remover(int idPaciente);
    }
}
