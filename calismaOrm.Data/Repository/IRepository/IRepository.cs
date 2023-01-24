using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace calismaOrm.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);


        //tek bir sorgu satırı çalışssın diye 
        T GetFirstOrDefault(Expression<Func<T, bool>> filter,
            string? includeProperties = null);

        //sorgu satırlarının bir liste halinde  gelmesini sağlamak için kullandık bu komut satırı ı  
        //GetOrFirst ve GetAll methodları direk crud işlemlerinden read yani  select secme,getirme işlemini yapar.
     IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        void RemoveRange(IEnumerable<T> entites);
        //bu methodu yazmamızın sebebi ise eger ıd silersek herhangş bişr tablodan diger tablodan foreign olan
        //alanların silinmesinide otomatik olarak sağlaması için yazdık.

    }
}
