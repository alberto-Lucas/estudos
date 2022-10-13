using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services
{
    public interface IDataStorage<T>
    {
        Task<bool> AdicionarAsync(T registro);
        Task<bool> AtualizarAsync(T registro);
        Task<bool> DeletarAsync(int id);
        Task<T> PesquisarAsync(int id); //pesquisando pelo id do item
        Task<IEnumerable<T>> PesquisarTodosAsync(bool forceRefresh = false); //retorna tudo
    }
}
