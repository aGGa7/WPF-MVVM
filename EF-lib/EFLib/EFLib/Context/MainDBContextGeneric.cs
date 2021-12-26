using EFLib.Models;
using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;

namespace EFLib.Context
{
    public class MainDBContextGeneric<T> : DbContext where T: BaseClass
    {
        //В этом конструкторе передается либо имя базы данных, либо полностью определенная строка подключения. 
        public MainDBContextGeneric(string connection) : base(connection)
        {
            // Указывает EF, что если модель изменилась,
            // нужно воссоздать базу данных с новой структурой
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainDBContextGeneric<T>>());
        }
        public DbSet<T> Repository { get; set; }

        //использую FluentApi для: 1)настройка генерации id при вставке нового объекта 2) настройка сложнных типов (справочников)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ObjectDesign>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //используется составной ключ 
            modelBuilder.Entity<DocumentPack>().HasKey(key => new { key.Mark.Name, key.Number }).Property(dp => dp.Number).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Document>().Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.ComplexType<Performer>();
            modelBuilder.ComplexType<Mark>();
            modelBuilder.ComplexType<TypeDoc>();
        }
    }
}
