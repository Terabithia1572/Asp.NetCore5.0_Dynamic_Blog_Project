using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        //burada 4 metodumuz olacak bu methodlardan
        // 3 ü Void olarak tutulacak (Create Update Delete)
        // 1 tanesi ise List olarak tutulacak (Read) yani Listele
        //List<Category> ListAllCategory(); // Kategorinin tümünü
        //                                  // getir demek
        //void AddCategory(Category category);
        //void DeleteCategory(Category category);
        //void UpdateCategory(Category category);

        //Category GetByID(int id); // güncelleme yapmak için
        //                            //bir id'ye göre güncelleme yapacağız
        //                            // o yüzden ID getirmemiz için bu methodu tanımladık
        



    }
}
