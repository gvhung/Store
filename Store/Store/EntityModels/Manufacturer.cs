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
    
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            this.Devices = new HashSet<Device>();
            this.VideoCards = new HashSet<VideoCard>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<VideoCard> VideoCards { get; set; }
    }
}