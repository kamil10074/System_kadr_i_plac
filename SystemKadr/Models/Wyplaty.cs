//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemKadr.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wyplaty
    {
        public int Id_tranzakcji { get; set; }
        public Nullable<int> Identyfikator { get; set; }
        public string Miesiac { get; set; }
        public Nullable<double> Wyplata { get; set; }
        public Nullable<int> Godziny { get; set; }
        public Nullable<int> Id_wpisu { get; set; }
    
        public virtual Godziny_przepracowane Godziny_przepracowane { get; set; }
        public virtual Pracownicy Pracownicy { get; set; }
    }
}
