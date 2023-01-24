using calismaOrm.Data.Repository.IRepository;
using calismaOrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calismaOrm.Data.Repository
{
    public class IletisimRepository
    {
        public class KategoriRepository : Repository<Iletisim>, IIletisimRepository
        {
            private ApplicationDbContext _context;
            public KategoriRepository(ApplicationDbContext context) : base(context)
            {
                _context = context;
            }
        }
}
