using System;
using System.Collections.Generic;

#nullable disable

namespace Travelus.DA.Models
{
    public partial class TbAuthorHasLibro
    {
        public int AuthorLibroId { get; set; }
        public int? AuthorId { get; set; }
        public int? Isbn { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual TblAuthor Author { get; set; }
        public virtual TblLibro IsbnNavigation { get; set; }
    }
}
