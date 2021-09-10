using System;
using System.Collections.Generic;

#nullable disable

namespace Travelus.DA.Models
{
    public partial class TblEditorial
    {
        public TblEditorial()
        {
            TblLibros = new HashSet<TblLibro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<TblLibro> TblLibros { get; set; }
    }
}
