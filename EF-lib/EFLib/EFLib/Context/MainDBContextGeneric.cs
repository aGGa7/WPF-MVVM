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
            //заполнение справочников начальными данными если они отсутсвуют в бд





































































































    -+6+56+
            Database.SetInitializer(new DropCreateDatabaseAlways<MainDBContextcs>());
        }
        public DbSet<T> Repository { get; set; }

        //использую FluentApi для: 1)настройка генерации id при вставке нового объекта 2) настройка сложнных типов (справочников)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Project>().HasRequired(p => p.Performer).WithOptional(p => p.Project);
            modelBuilder.Entity<ObjectDesign>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Document>().Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Document>().HasRequired(d => d.TypeDoc).WithOptional(t => t.Document);
            //modelBuilder.ComplexType<Performer>();
            //modelBuilder.ComplexType<Mark>();
            //modelBuilder.ComplexType<TypeDoc>();
            //используется составной ключ 
            modelBuilder.Entity<DocumentPack>().HasKey(key => new { key.MarkName, key.Number }).Property(dp => dp.Number).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<DocumentPack>().HasRequired(d => d.Mark).WithOptional(m => m.DocumentPack);
        }
    }
}
