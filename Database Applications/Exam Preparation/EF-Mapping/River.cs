//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkMapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class River
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public River()
        {
            this.Countries = new HashSet<Country>();
        }
    
        public int Id { get; set; }
        public string RiverName { get; set; }
        public int Length { get; set; }
        public Nullable<int> DrainageArea { get; set; }
        public Nullable<int> AverageDischarge { get; set; }
        public string Outflow { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Country> Countries { get; set; }
    }
}
