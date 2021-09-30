using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int IdEndereco { get; set; }
        public string Lugadouro { get; set; }
        public string Endereco1 { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
