using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    public class LibroBLL
    {
        public static void Create(Libro a)
        {
            using (DBEntities db = new DBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libro.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Libro Get(int? id)
        {
            DBEntities db = new DBEntities();
            return db.Libro.Find(id);
        }

        public static void Update(Libro Libro)
        {
            using (DBEntities db = new DBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libro.Attach(Libro);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (DBEntities db = new DBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Libro Libro = db.Libro.Find(id);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Libro> List()
        {
            DBEntities db = new DBEntities();
            return db.Libro.ToList();
        }

        public static List<Libro> ListToNames()
        {
            DBEntities db = new DBEntities();
            List<Libro> result = new List<Libro>();
            db.Libro.ToList().ForEach(x =>
                result.Add(
                    new Libro
                    {
                        titulo = x.ISBN + "-" + x.titulo,
                        idlibro = x.idlibro
                    }));
            return result;
        }
    }
}
