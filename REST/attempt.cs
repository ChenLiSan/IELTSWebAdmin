//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace REST
{
    using System;
    using System.Collections.Generic;
    
    public partial class attempt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public attempt()
        {
            this.candidates = new HashSet<candidate>();
        }
    
        public int attemptID { get; set; }
        public Nullable<int> candidate { get; set; }
        public Nullable<int> paper { get; set; }
        public Nullable<int> sessionID { get; set; }
        public string record { get; set; }
        public string log { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<candidate> candidates { get; set; }
        public virtual session session { get; set; }
    }
}
