using LoginSqLITE.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSqLITE.Services
{
    public class UsuarioService : IDataStore<Usuario>
    {
        private DatabaseService databaseService;
        private SQLiteAsyncConnection _conexao;

        public UsuarioService()
        {
            databaseService = new DatabaseService();
            _conexao = databaseService.GetConnection(); //recupera conexão com o banco de dados
            _conexao.CreateTableAsync<Usuario>().Wait(); //mapear classe para criação de tabelas
        }

        # region Metodo base da interface
        public async Task<bool> AddAsync(Usuario usuario)
        {
            await _conexao.InsertAsync(usuario);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            await _conexao.UpdateAsync(usuario);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(Usuario usuario)
        {
            await _conexao.DeleteAsync(usuario);
            return await Task.FromResult(true);
        }

        public async Task<Usuario> GetByIdAsync(int value)
        {
            return await _conexao.FindAsync<Usuario>(value);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _conexao.Table<Usuario>().OrderByDescending(x => x.Nome).ToListAsync();
        }
        #endregion

        //Metodo personalizado de persistencia de dados
        public async Task<Usuario> GetLoginAsync(string value)
        {
            return await _conexao.Table<Usuario>().FirstOrDefaultAsync(t => t.Email == value);
        }
    }
}
