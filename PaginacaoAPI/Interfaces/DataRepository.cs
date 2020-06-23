using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaginacaoAPI.Model;
using PaginacaoAPI.Utils;

namespace PaginacaoAPI.Interfaces
{
    public class DataRepository : IDataRepository
    {
        private readonly AppContext _appContext;

        public DataRepository(AppContext appContext)
        {
            _appContext = appContext;
        }
        public IQueryable<Pessoa> GetAll(PaginacaoDto paginacao)
        {
            return Paginacao<Pessoa>.ToPaginacao(_appContext.Pessoa.OrderBy(p => p.Id),
                paginacao.PageNumber, paginacao.PageSize).AsQueryable();
        }

        public void Add(Pessoa entity)
        {
            _appContext.Add(entity);
        }

        public void AddRange(IEnumerable<Pessoa> entity)
        {
            _appContext.AddRangeAsync(entity);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _appContext.SaveChangesAsync()) > 0;
        }
    }
}
