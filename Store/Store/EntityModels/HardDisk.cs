//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.EntityModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class HardDisk
    {
        public HardDisk()
        {
            this.Devices = new HashSet<Device>();
        }
    
        public int Id { get; set; }
        public string HDD { get; set; }
        public string SSD { get; set; }
    
        public virtual ICollection<Device> Devices { get; set; }
    }
}