
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ObtenerPesoSAP.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class CPLogDeProcesos
{

        public int CPIdLog { get; set; }

        public int CPIdEmpresa { get; set; }
        [DisplayFormat(DataFormatString = "{0:F0}")]
        [DisplayName("Transporte")]
        [RegularExpression(@"[0-9]*\.?[0-9]*", ErrorMessage = "La cantidad debe contener s�lo n�meros")]
        public Nullable<decimal> CPIdTransporte { get; set; }

        public Nullable<decimal> CPIdDocumento { get; set; }

        public Nullable<decimal> CPIdMaterial { get; set; }

        public int CPIdErrorSAP { get; set; }
        [DisplayName("Descripcion del Movimiento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "la descripcion no puede ir vacia")]
        public string CPDescripcionMensaje { get; set; }

        public Nullable<int> CPPartidas { get; set; }
        [DisplayName("Inicio")]
        public Nullable<System.DateTime> CPFechaInicio { get; set; }
        [DisplayName("Finalizo")]
        public Nullable<System.DateTime> CpFechaFinal { get; set; }
        [DisplayName("Usuario")]
        public int CPIdUsuario { get; set; }

        public Nullable<int> CPIdProceso { get; set; }
        [DisplayName("Estatus")]
        public string CPEstatus { get; set; }
        public Nullable<int> CPRol { get; set; }




        public virtual CPCatEmpresas CPCatEmpresas { get; set; }

    public virtual CPCatProcesos CPCatProcesos { get; set; }

    public virtual CPUsuario CPUsuario { get; set; }

}

}
