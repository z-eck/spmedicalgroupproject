using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public short? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
    }
}
