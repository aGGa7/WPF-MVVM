using EFLib.Context;
using EFLib.CRUD;
using EFLib.Models;
using System.Data.Entity;

namespace EFLib.Data
{
    public class DataInit<T> : DropCreateDatabaseIfModelChanges<MainDBContextGeneric<T>> where T: BaseClass
    {
        protected override void Seed(MainDBContextGeneric<T> context)
        {
            base.Seed(context);
        }
    }
}
