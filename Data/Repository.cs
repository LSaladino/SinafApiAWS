using Microsoft.EntityFrameworkCore;
using SinafApi.Models;

namespace SinafApi.Data
{

    public class Repository : IRepository
    {
        private readonly MyDataContext _context;
        public Repository(MyDataContext context)
        {
            _context = context;
        }
        public void CreateData<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void DeleteData<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveDataAsynch()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void UpdateData<T>(T entity) where T : class
        {
            _context.Update(entity);
        }


        public async Task<Boleto[]> GetAllBoletoAsynch()
        {
            IQueryable<Boleto>? query = _context.Boletos;

            query = query!.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Boleto> GetBoletoAsynchById(int boletoId)
        {
            IQueryable<Boleto>? query = _context.Boletos;

            query = query!.AsNoTracking().Where(c => c.Id == boletoId).OrderBy(c => c.Id);

            var retorno = await query.FirstOrDefaultAsync();

            return retorno!;
        }

        public async Task<Pix[]> GetAllPixAsynch()
        {
            IQueryable<Pix>? query = _context.Pixes;

            query = query!.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Pix> GetPixAsynchById(int pixId)
        {
            IQueryable<Pix>? query = _context.Pixes;

            query = query!.AsNoTracking().Where(c => c.Id == pixId).OrderBy(c => c.Id);

            var retorno = await query.FirstOrDefaultAsync();

            return retorno!;
        }

        public async Task<MeioPagamento[]> GetAllMeioPagAsynch()
        {
            IQueryable<MeioPagamento>? query = _context.MeioPagamentos;

            query = query!.AsNoTracking()
            .Where(p => p.Processado != "S")
                         .OrderBy(c => c.Id);

            var retorno = await query.ToArrayAsync();

            return retorno;
        }

        public async Task<MeioPagamento> GetMeioPagAsynchById(int meiopagId)
        {
            IQueryable<MeioPagamento>? query = _context.MeioPagamentos;

            query = query!.AsNoTracking().Where(c => c.Id == meiopagId).OrderBy(c => c.Id);

            var retorno = await query.FirstOrDefaultAsync();

            return retorno!;
        }
    }
}