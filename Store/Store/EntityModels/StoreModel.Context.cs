﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities2 : DbContext
    {
        public Entities2()
            : base("name=Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DicProdType> DicProdTypes { get; set; }
        public virtual DbSet<HardDisk> HardDisks { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<OperatingSystem> OperatingSystems { get; set; }
        public virtual DbSet<Power> Powers { get; set; }
        public virtual DbSet<Processor> Processors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<VideoCard> VideoCards { get; set; }
        public virtual DbSet<Display> Displays { get; set; }
    }
}