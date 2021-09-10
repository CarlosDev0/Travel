using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Travelus.DA.Models
{
    public partial class TblLibro
    {
        public TblLibro()
        {
            TbAuthorHasLibros = new HashSet<TbAuthorHasLibro>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public int Isbn { get; set; }
        [BindProperty]
        public int? EditorialId { get; set; }
        [DisplayName("Title")]
        public string Titulo { get; set; }
        [DisplayName("Synopsis")]
        public string Sinopsis { get; set; }
        [DisplayName("Pages")]
        public string NPaginas { get; set; }
        [DisplayName("CreationDate")]
        public DateTime? FechaCreacion { get; set; }
        [DisplayName("CreationUser")]
        public string UsuarioCreacion { get; set; }
        [DisplayName("ModificationDate")]
        public DateTime? FechaModificacion { get; set; }
        [DisplayName("ModificationUser")]
        public string UsuarioModificacion { get; set; }

        public virtual TblEditorial Editorial { get; set; }
        public virtual ICollection<TbAuthorHasLibro> TbAuthorHasLibros { get; set; }
    }
}
