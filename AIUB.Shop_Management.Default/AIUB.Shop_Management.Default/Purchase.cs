//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIUB.Shop_Management.Default
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public string ProductId { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public string UnitPrice { get; set; }
        public string PurchaseQuentity { get; set; }
    
        public virtual Product_Brand Product_Brand { get; set; }
    }
}