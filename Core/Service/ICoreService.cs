using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICoreService<T> where T:BaseEntity
    {
        //Ekleme
        void Add(T model);
        //Liste olarak ekleme
        void Add(List<T> models);

        //Tekil olarak getirme
        T GetById(Guid id);

        //Geriye Liste Halinde Verilerin Dönmesi
        List<T> GetAll();

        //Silme
        void Remove(Guid id);

        //Güncelleme
        void Update(T model);

        //Kriter (Filitreleme)
        List<T> GetDefault(Expression<Func<T, bool>> exp);

        //Var mı Yok mu?
        bool Any(Expression<Func<T, bool>> exp);

        //Sadece aktif olanları listeleme
        List<T> GetActive();
    }
}
