using EFLib.Context;
using EFLib.CRUD;
using EFLib.Models;
using EFLib.Models.Catalogs;
using System.Data.Entity;

namespace EFLib.Data
{
    public class DataInit : DropCreateDatabaseAlways<MainDBContextcs> 
    {
        protected override void Seed(MainDBContextcs context) 
        {
            if (!context.Performers.AnyAsync().Result)
            {
                context.Performers.Add(new Performer { Name = "Петон", FullName = "ООО «НИПИ НГ «Петон»", Id = new System.Guid() });
                context.Performers.Add(new Performer { Name = "Суб1", FullName = "Субподрядчик 1", Id = new System.Guid() });
            }
            if(!context.Marks.AnyAsync().Result)
            {
                context.Marks.Add(new Mark { Name = "ТХ", FullName = "Технология производства", Id = new System.Guid() });
                context.Marks.Add(new Mark { Name = "АС", FullName = "Архитектурно-строительные решения", Id = new System.Guid() });
                context.Marks.Add(new Mark { Name = "СМ", FullName = "Сметная документация", Id = new System.Guid() });
            }
            if(!context.TypeDocs.AnyAsync().Result)
            {
                context.TypeDocs.Add(new TypeDoc { Name = "ОД", FullName = "Общие данные", Id = new System.Guid() });
                context.TypeDocs.Add(new TypeDoc { Name = "Ч", FullName = "Чертеж", Id = new System.Guid() });
                context.TypeDocs.Add(new TypeDoc { Name = "С", FullName = "Спецификация", Id = new System.Guid() });
            }
            base.Seed(context);
        }
    }

    //public static class DataInit
    //{
    //    public static void SeedTypeDoc(this MainDBContextGeneric<TypeDoc> context)
    //    {

    //        if (!context.Repository.AnyAsync().Result)
    //        {
    //            context.Repository.Add(new TypeDoc { Name = "ОД", FullName = "Общие данные", Id = new System.Guid() });
    //            context.Repository.Add(new TypeDoc { Name = "Ч", FullName = "Чертеж", Id = new System.Guid() });
    //            context.Repository.Add(new TypeDoc { Name = "С", FullName = "Спецификация", Id = new System.Guid() });
    //            context.SaveChanges();
    //        }
    //    }
    //    public static void SeedPerformer(this MainDBContextGeneric<Performer> context)
    //    {
    //        if (!context.Repository.AnyAsync().Result)
    //        {
    //            context.Repository.Add(new Performer { Name = "Петон", FullName = "ООО «НИПИ НГ «Петон»", Id = new System.Guid() });
    //            context.Repository.Add(new Performer { Name = "Суб1", FullName = "Субподрядчик 1", Id = new System.Guid() });
    //            context.SaveChanges();
    //        }
    //    }
    //    public static void SeedMark(this MainDBContextGeneric<Mark> context)
    //    {
    //        if (!context.Repository.AnyAsync().Result)
    //        {
    //            context.Repository.Add(new Mark { Name = "ТХ", FullName = "Технология производства", Id = new System.Guid() });
    //            context.Repository.Add(new Mark { Name = "АС", FullName = "Архитектурно-строительные решения", Id = new System.Guid() });
    //            context.Repository.Add(new Mark { Name = "СМ", FullName = "Сметная документация", Id = new System.Guid() });
    //            context.SaveChanges();
    //        }
    //    }
    //}
}
