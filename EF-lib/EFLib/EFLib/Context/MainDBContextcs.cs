using EFLib.Models;
using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;

namespace EFLib.Context
{
    public class MainDBContextcs : DbContext
    {
        //наименование дб
        public MainDBContextcs() : base()
        {
            // Указывает EF, что если модель изменилась,
            // нужно воссоздать базу данных с новой структурой
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainDBContextcs>());
        }

        public MainDBContextcs(string connection) : base(connection)
        {
            // Указывает EF, что если модель изменилась,
            // нужно воссоздать базу данных с новой структурой
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainDBContextcs>());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ObjectDesign> Objects { get; set; }
        public DbSet<DocumentPack> DocumentPacks { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<TypeDoc> TypeDocs { get; set; }
        public DbSet<Mark> Marks { get; set; }

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
