//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabTask_2.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerProduct
    {
        public int ID { get; set; }
        public int C_ID { get; set; }
        public int P_ID { get; set; }
        public int OrderDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
