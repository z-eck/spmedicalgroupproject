using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Tipousuario
    {
        public Tipousuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string DescricaoTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
