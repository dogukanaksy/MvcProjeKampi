using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context c= new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p); //veritabanı ile ilişkilendirilmiş bir nesneye erişmek için kullanılır. Bu nesne üzerinden ekleme, silme, güncelleme gibi işlemler yapılabilir.
            deletedEntity.State = EntityState.Deleted; //silme işlemi için kullanılır.
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //Bir dizide veya liste içinde tek bir değer döndürmek için kullanılır. Eğer birden fazla değer döndürürse hata verir.
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p); //veritabanı ile ilişkilendirilmiş bir nesneye erişmek için kullanılır. Bu nesne üzerinden ekleme, silme, güncelleme gibi işlemler yapılabilir.
            addedEntity.State = EntityState.Added; //ekleme işlemi için kullanılır.
            //_object.Add(p); //veritabanına ekleme işlemi için kullanılır.
            c.SaveChanges(); //veritabanına ekleme işlemi için kullanılır.
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter) //komple bir liste döndürürmek için kullanılır. Örn: Aktif olan kategorileri listele gibi.
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p); //veritabanı ile ilişkilendirilmiş bir nesneye erişmek için kullanılır. Bu nesne üzerinden ekleme, silme, güncelleme gibi işlemler yapılabilir.
            updatedEntity.State = EntityState.Modified; //güncelleme işlemi için kullanılır.    
            c.SaveChanges(); 
        }
    }
}
