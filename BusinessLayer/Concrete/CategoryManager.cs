using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
            if(p.CategoryName=="null" || p.CategoryName.Length<=3 || p.CategoryDescription=="" | p.CategoryName.Length>=51)
            {
                // hata mesajı
                Console.WriteLine("Koşullar karşılanmadı. Veri eklenmedi.");

            }
            else
            {
                repo.Insert(p);
                Console.WriteLine("Başarılı şekilde eklendi.");
                //Başarılı mesajı
            }
        }
    }
}
