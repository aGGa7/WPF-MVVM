﻿using EFLib.Context;
using System.Linq;
using System.Collections.Generic;
using EFLib.Models;
using System.Data.Entity.Migrations;
using System;

namespace EFLib.CRUD
{
    public class MainRepository
    {
        private MainDBContextcs context = new MainDBContextcs();
        string connection;
        public MainRepository (string conn)
        {
            connection = conn;
            context = new MainDBContextcs(connection);
        }
        public IQueryable<Project> Projects => context.Projects;
        public void SaveProject (Project prj)
        {
            try
            {
                //if (prj.Id == System.Guid.Empty)
                //    context.Projects.Add(prj);
                //else
                //{
                //    Project dbEntry = context.Projects.FirstOrDefault(p => p.Id == prj.Id);
                //    if(dbEntry != null)
                //    {
                //        context.Projects.Remove(dbEntry);
                //        context.Projects.Add(prj);
                //    }
                //}
                context.Projects.AddOrUpdate(p => new { p.Id }, prj);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
           
        }
        public void DeleteProject(Guid id)
        {
            try
            {
                Project dbEntry = context.Projects.FirstOrDefault(p => p.Id == id);
                if (dbEntry != null)
                {
                    context.Projects.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        } 
    }
}