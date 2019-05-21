

namespace SystemKadr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Pracownicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pracownicy()
        {
            this.Godziny_przepracowane = new HashSet<Godziny_przepracowane>();
            this.Wyplaty = new HashSet<Wyplaty>();
        }

        public int Identyfikator { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Nullable<int> PESEL { get; set; }
        public Nullable<int> Wydzial { get; set; }
        public double Stawka_zaszeregowana { get; set; }
        public string Rodzaj_umowy { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Data_podjecia_pracy { get; set; }
        public string Miejscowosc { get; set; }
        public int Rola { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Godziny_przepracowane> Godziny_przepracowane { get; set; }
        public virtual Role Role { get; set; }
        public virtual Wydzialy Wydzialy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wyplaty> Wyplaty { get; set; }
    }
}
