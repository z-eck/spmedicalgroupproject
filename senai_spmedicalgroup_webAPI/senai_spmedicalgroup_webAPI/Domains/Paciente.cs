using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Agendamentos = new HashSet<Agendamento>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPaciente { get; set; }
        public int? IdEndereco { get; set; }
        public string NomePaciente { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string DddTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string NumeroEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
