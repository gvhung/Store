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
    
    public partial class Product
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public System.DateTime DateOfCreate { get; set; }
        public string Color { get; set; }
    
        public virtual Device Device { get; set; }
    }
}
