using System;
using System.Collections.Generic;

#nullable disable

namespace Travelus.DA.Models
{
    public partial class TblAuthor
    {
        public TblAuthor()
        {
            TbAuthorHasLibros = new HashSet<TbAuthorHasLibro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<TbAuthorHasLibro> TbAuthorHasLibros { get; set; }
    }
}
