using BackEndApiSimple.Models;

namespace BackEndApiSimple.Services.Contracts
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetList();
        Task<Categoria> Get(int id);
        Task<int> Insert(Categoria categoria);
        Task<int> Update(Categoria categoria);
        Task<int> Delete(Categoria categoria);
    }
}
