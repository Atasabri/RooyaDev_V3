//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RooyaDev.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project_Videos
    {
        public int ID { get; set; }
        public string Link { get; set; }
        public int Project_ID { get; set; }
    
        public virtual Project Project { get; set; }
    }
}