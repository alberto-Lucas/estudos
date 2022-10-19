using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginSqLITE.Services
{
    public class DatabaseService
    {
        public SQLiteAsyncConnection connection;

        public SQLiteAsyncConnection GetConnection()
        {
            var folder = new LocalRootFolder();
            //Definimos o nome do banco de dados
            //Configuramos para caso o arquivo não exista seja criado
            //Caso exista seja atualizado
            var file = folder.CreateFile("oraculo", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //Criando conexao com o banco de dados
            return connection = new SQLiteAsyncConnection(file.Path);
        }
    }
}
