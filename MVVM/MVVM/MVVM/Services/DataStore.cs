using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services
{
    public class DataStore : IDataStorage<Cliente>
    {

        readonly List<Cliente> clientes;

        public DataStore()
        { 
            clientes = new List<Cliente>()
            { 
                
            };
        }

        public async Task<bool> AdicionarAsync(Cliente registro)
        {
            clientes.Add(registro);
            return await Task.FromResult(true); //retornar inserção com sucesso
        }

        public async Task<bool> AtualizarAsync(Cliente registro)
        {
            //neste caso em expcepcional como não é possivel dar update em um registro da list
            //iremos remover o item e adicionar novamente

            var registroAntigo = clientes.Where((Cliente arg) => arg.ClienteId == registro.ClienteId).FirstOrDefault();
            clientes.Remove(registroAntigo);
            clientes.Add(registro);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            //semelhante ao processo do update no cenario de list, porém iremos passar nosso id direto
            var registroAntigo = clientes.Where((Cliente aux) => aux.ClienteId == id).FirstOrDefault();
            clientes.Remove(registroAntigo);

            return await Task.FromResult(true);
        }

        public async Task<Cliente> PesquisarAsync(int id)
        {
            return await Task.FromResult(clientes.FirstOrDefault(aux => aux.ClienteId == id));
        }

        public async Task<IEnumerable<Cliente>> PesquisarTodosAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(clientes);
        }
    }
}
