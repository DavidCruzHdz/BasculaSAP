
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
    
public partial class CPAutorizaciones
{

    public int CPIdAutorizacion { get; set; }

    public int CPIdEmpresa { get; set; }

    public Nullable<decimal> CPIdTransporte { get; set; }

    public Nullable<decimal> CPIdDocumento { get; set; }

    public string CPMotivoAutorizacion { get; set; }

    public int CPIdPartidas { get; set; }

    public System.DateTime CpFechaAutorizacion { get; set; }

    public int CPIdUsuario { get; set; }



    public virtual CPCatEmpresas CPCatEmpresas { get; set; }

    public virtual CPUsuario CPUsuario { get; set; }

}

}
