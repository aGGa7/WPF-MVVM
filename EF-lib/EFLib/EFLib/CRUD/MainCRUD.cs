using EFLib.Context;
using System.Linq;
using System.Collections.Generic;
using EFLib.Models;
using System.Data.Entity.Migrations;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace EFLib.CRUD
{
    public class MainCRUD<T> : IDisposable, IRepo<T> where T: BaseClass, new()
    {
        private MainDBContextGeneric<T> context { get; set; }
        private string connection;
        public MainCRUD(string conn)
        {
            connection = conn;
            context = new MainDBContextGeneric<T>(connection);
        }
        public MainCRUD(MainDBContextGeneric<T> dbctx)
        {
            context = dbctx;
        }
        public int Add(T entity)
        {
            context.Repository.Add(entity);
            return SaveChanges();
        }
        public int AddOrUpdate(T entity)
        {
            context.Repository.AddOrUpdate(p => new { p.Id }, entity);
           return SaveChanges();
        }

        public int AddRange(IList<T> entities)
        {
            context.Repository.AddRange(entities);
            return SaveChanges();
        }

        public int Delete(Guid id)
        {
            context.Entry(new T() { Id = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        public List<T> GetAll()
        {
            return context.Repository.ToList();
        }

        public T GetOne(int? id)
        {
           return context.Repository.Find(id);
        }

        public int Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        internal int SaveChanges ()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Генерируется, когда возникает ошибка, связанная с параллелизмом.
                // Пока что просто повторно сгенерировать исключение,
                throw;
            }
            catch (DbUpdateException ex)
            {
                // Генерируется, когда обновление базы данных терпит неудачу.
                // Проверить внутреннее исключение (исключения), чтобы получить
                // дополнительные сведения и выяснить, на какие объекты это повлияло.
                // Пока что просто повторно сгенерировать исключение.
                throw;
            }
            catch (CommitFailedException ex)
            {
                // Обработать здесь отказы транзакции.
                // Пока что просто повторно сгенерировать исключение,
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
