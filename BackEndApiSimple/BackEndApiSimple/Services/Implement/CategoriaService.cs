using BackEndApiSimple.Data;
using BackEndApiSimple.Models;
using BackEndApiSimple.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BackEndApiSimple.Services.Implement
{
    public class CategoriaService: ICategoriaService
    {
        public readonly ClaseProductoContext _context;

        public CategoriaService(ClaseProductoContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(Categoria categoria)
        {
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return categoria.Id;
        }

        public async Task<List<Categoria>> GetList()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Categoria> Get(int id)
        {
            return await _context.Categoria.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Insert(Categoria categoria)
        {
             _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();


            return categoria.Id;
        }

        public async Task<int> Update(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria.Id;
        }
    }
}
