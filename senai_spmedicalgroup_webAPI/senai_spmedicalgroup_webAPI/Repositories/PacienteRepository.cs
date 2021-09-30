using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        readonly SPMEDICALGROUPContext context = new();
        public void AtualizarURL(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = context.Pacientes.Find(idPaciente);

            if (pacienteAtualizado.NomePaciente != null || pacienteAtualizado.DataNascimento != null || pacienteAtualizado.Cpf != null)
            {
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
                pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;

                context.Pacientes.Update(pacienteBuscado);

                context.SaveChanges();
            }
        }

        public Paciente BuscarPorID(int idPaciente)
        {
            return context.Pacientes
                .Select(p => new Paciente
                {
                    IdPaciente = p.IdPaciente,
                    NomePaciente = p.NomePaciente,
                    DataNascimento = p.DataNascimento,
                    DddTelefone = p.DddTelefone,
                    NumeroTelefone = p.NumeroTelefone,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    IdEnderecoNavigation = new Endereco()
                    {
                        Cep = p.IdEnderecoNavigation.Cep,
                        Uf = p.IdEnderecoNavigation.Uf,
                        Cidade = p.IdEnderecoNavigation.Cidade,
                        Bairro = p.IdEnderecoNavigation.Bairro,
                        Lugadouro = p.IdEnderecoNavigation.Lugadouro,
                        Endereco1 = p.IdEnderecoNavigation.Endereco1,
                    },
                    NumeroEndereco = p.NumeroEndereco,
                })
                .FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            context.Pacientes.Add(novoPaciente);

            context.SaveChanges();
        }

        public List<Paciente> ListarTodos(int idPaciente)
        {
            return context.Pacientes
                .Select(p => new Paciente
                {
                    IdPaciente = p.IdPaciente,
                    NomePaciente = p.NomePaciente,
                    DataNascimento = p.DataNascimento,
                    DddTelefone = p.DddTelefone,
                    NumeroTelefone = p.NumeroTelefone,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    IdEnderecoNavigation = new Endereco()
                    {
                        Cep = p.IdEnderecoNavigation.Cep,
                        Uf = p.IdEnderecoNavigation.Uf,
                        Cidade = p.IdEnderecoNavigation.Cidade,
                        Bairro = p.IdEnderecoNavigation.Bairro,
                        Lugadouro = p.IdEnderecoNavigation.Lugadouro,
                        Endereco1 = p.IdEnderecoNavigation.Endereco1,
                    },
                    NumeroEndereco = p.NumeroEndereco,
                })
                .OrderBy (p => p.NomePaciente)
                .ToList();
        }

        public void Remover(int idPaciente)
        {
            context.Pacientes.Remove(BuscarPorID(idPaciente));

            context.SaveChanges();
        }
    }
}
