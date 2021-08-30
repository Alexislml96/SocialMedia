using System;
using System.Collections.Generic;

#nullable disable

namespace SocialMedia.Core.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            Comentarios = new HashSet<Comentario>();
            Publicacions = new HashSet<Publicacion>();
        }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Publicacion> Publicacions { get; set; }
    }
}
