using calismaOrm.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calismaOrm.Data.Repository.IRepository
{
    public interface IUnitofWork : IDisposable
    {
     

        IKategoriRepository Kategori { get; }

        IUrunlerRepository Urunler { get; }


        void Save();

    }
}
