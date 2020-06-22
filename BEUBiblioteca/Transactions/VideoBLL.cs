using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    public class VideoBLL
    {
        public static void Create(Video a)
        {
            using (DBEntities db = new DBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Video.Add(a);
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

        public static Video Get(int? id)
        {
            DBEntities db = new DBEntities();
            return db.Video.Find(id);
        }

        public static void Update(Video Video)
        {
            using (DBEntities db = new DBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Video.Attach(Video);
                        db.Entry(Video).State = System.Data.Entity.EntityState.Modified;
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
                        Video Video = db.Video.Find(id);
                        db.Entry(Video).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Video> List()
        {
            DBEntities db = new DBEntities();
            return db.Video.ToList();
        }

        public static List<Video> ListToNames()
        {
            DBEntities db = new DBEntities();
            List<Video> result = new List<Video>();
            db.Video.ToList().ForEach(x =>
                result.Add(
                    new Video
                    {
                        titulo = x.formato + "-" + x.titulo,
                        idvideo = x.idvideo
                    }));
            return result;
        }
    }
}
