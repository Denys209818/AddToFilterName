using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddElementToFilterName.Entities
{
    public class EFContext : DbContext
    {
        public DbSet<FilterName> FilterNames { get; set; }
        public DbSet<FilterValue> FilterValues { get; set; }
        public DbSet<FilterNameValue> FilterNameValues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=denysdb;Username=denys;Password=qwerty1*;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Встановлення звязків
            modelBuilder.Entity<FilterNameValue>(filterNameValueParams => 
            {
                //  Встановлення Primary Key до елементів проміжної таблички FilterNameValue
                filterNameValueParams.HasKey(primaryKeys => new 
                { primaryKeys.FilterNameId, primaryKeys.FilterValueId });

                //  Встановлення звязку віртуального елемента до віртуальної колекції
                filterNameValueParams.HasOne(virtualElementFromFilterNameValue =>
                virtualElementFromFilterNameValue.FilterName)
                .WithMany(virtualCollectionWithEntityToVirEl => virtualCollectionWithEntityToVirEl.NameValues)
                //  Поле до якого застосовуються налаштування
                .HasForeignKey(intElementWithForeignKeySettings => intElementWithForeignKeySettings.FilterNameId)
                .IsRequired();

                //  Встановлення звязку віртуального елемента до віртуальної колекції
                filterNameValueParams.HasOne(virtualElementFromFilterNameValue => 
                virtualElementFromFilterNameValue.FilterValue)
                .WithMany(virtualCollectionWithEntityToVirEl => virtualCollectionWithEntityToVirEl.NameValues)
                //  Поле до якого застосовуються налаштування
                .HasForeignKey(intElementWithForeignKeySettings => intElementWithForeignKeySettings.FilterValueId)
                .IsRequired();
            });
        }
    }
}
