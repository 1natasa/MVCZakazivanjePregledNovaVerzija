//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCZakazivanjePregleda.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwPacijent
    {
        public int pacijentID { get; set; }
        public string imePacijenta { get; set; }
        public string prezimePacijenta { get; set; }
        public string adresaPacijenta { get; set; }
        public string polPacijenta { get; set; }
        public Nullable<System.DateTime> datumRodjenjaPacijenta { get; set; }
        public string jmbgPacijenta { get; set; }
        public string brojTelefonaPacijenta { get; set; }
        public string lbo { get; set; }
    }
}
