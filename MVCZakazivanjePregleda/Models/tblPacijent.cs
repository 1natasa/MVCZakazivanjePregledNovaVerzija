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
    using System.ComponentModel.DataAnnotations;

    public partial class tblPacijent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPacijent()
        {
            this.tblPregleds = new HashSet<tblPregled>();
        }

        public int pacijentID { get; set; }
        [System.ComponentModel.DisplayName("Ime")]
        public string imePacijenta { get; set; }

        [System.ComponentModel.DisplayName("Prezime")]
        public string prezimePacijenta { get; set; }

        [System.ComponentModel.DisplayName("Adresa")]
        public string adresaPacijenta { get; set; }

        [System.ComponentModel.DisplayName("Pol")]
        public string polPacijenta { get; set; }


        [System.ComponentModel.DisplayName("Datum rodjenja")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> datumRodjenjaPacijenta { get; set; }

        [System.ComponentModel.DisplayName("JMBG")]
        public string jmbgPacijenta { get; set; }
        [System.ComponentModel.DisplayName("Broj telefona")]
        public string brojTelefonaPacijenta { get; set; }

        [System.ComponentModel.DisplayName("LBO")]
        public string lbo { get; set; }

        [System.ComponentModel.DisplayName("Pacijent")]
        public string pacijent
        {
            get
            {
                return imePacijenta + " " + prezimePacijenta;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPregled> tblPregleds { get; set; }
    }
}
