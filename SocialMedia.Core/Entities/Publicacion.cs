using System;
using System.Collections.Generic;

#nullable disable

namespace SocialMedia.Core.Entities
{
    public partial class Publicacion : BaseEntity
    {
        public Publicacion()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
