using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using calismaOrm.Data.Repository.IRepository;

namespace calismaOrm.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //sadece burda kullanmak istedigim context sınıfımı sadece okunabilir sekilde tanımladım.
        private readonly ApplicationDbContext _context;
        //-------------------------------------------------------------------------------------
        //yazdıgım kodları daha kısa bir tanımlama yaparak kullanmak için proje icinden rahatlıkla 
        //cagırmak adına internal yapıyorum.internal olarak dbset olustrdum burdaki dbseti benden kalıtım olarak 
        //alan sınıflarda kullanabilmek istiyorum.otüzden buşelikde tanımlıyorum 
        internal DbSet<T> _dbSet;

        //----------------------------------------------------------------------------------------------

        //dependincity injection gercekleebilmesin contructor olusturup apllication dbbilgisini alalım
        //burda applicationcontext  dependcy injection  aracılıgı ile alabilmek için tanımlıyorum 
        //bana gelen contexti   _context olarak tanımlıyorum 
        //-dbset kullanmamımın sebebi ise get set işlemleri yapmamamk için 
        //prstik sekilde cagrılma işlemleri olmasını saglamak için direk tanımlıyoruz.
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                //x=x.id=1;
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                //x=x.id=1;
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            _dbSet.RemoveRange(entites);
        }

        public void Update(T entity)
        {

            _dbSet.Update(entity);


        }
    }
}
