using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using calismaOrm.Data.Repository.IRepository;

namespace calismaOrm.Data.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IKategoriRepository Kategori => new KategoriRepository(_context);
        public IUrunlerRepository Urunler => new UrunlerRepository(_context);
        public void Dispose()
        {
            _context.Dispose();

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
