using System.Collections.Generic;
using PaginacaoAPI.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PaginacaoAPI.Interfaces
{
    public interface IDataRepository
    {
        public IQueryable<Pessoa> GetAll(PaginacaoDto paginacao);
        public void Add(Pessoa entity);
        public void AddRange(IEnumerable<Pessoa> entity);
        public Task<bool> SaveChanges();
    }
}
