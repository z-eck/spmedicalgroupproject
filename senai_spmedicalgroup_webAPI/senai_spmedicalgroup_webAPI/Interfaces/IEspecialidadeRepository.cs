using senai_spmedicalgroup_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> ListarTodos();

        Especialidade BuscarPorID(int idEspecialidade);

        void Cadastrar(Especialidade novaEspecialidade);

        void AtualizarURL(int idEspecialidade, Especialidade especialidadeAtualizada);

        void Remover(int idEspecialidade);
    }
}
