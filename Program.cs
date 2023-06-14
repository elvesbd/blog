using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        //Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Encrypt=false
        private const string CONNECTION_STRING = @"
            Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Encrypt=false
        ";
        static void Main(string[] args)
        {
            // ReadUsers();
            // ReadUser(1);
            // CreateUser();
            // UpdateUser(2);
            DeleteUser(2);
        }

        public static void ReadUsers()
        {
            var repository = new UserRepository();
            var users = repository.Get();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        public static void ReadUser(int id)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var user = connection.Get<User>(id);
            Console.WriteLine(user.Name);
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using var connection = new SqlConnection(CONNECTION_STRING);
            connection.Insert<User>(user);
            Console.WriteLine("Cadastro realizado com sucesso!");
        }

        public static void UpdateUser(int id)
        {
            var user = new User()
            {
                Id = id,
                Bio = "Equipe | balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using var connection = new SqlConnection(CONNECTION_STRING);
            connection.Update<User>(user);
            Console.WriteLine("Atualização efetuada com sucesso!");
        }

        public static void DeleteUser(int id)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var user = connection.Get<User>(id);
            connection.Delete<User>(user);
            Console.WriteLine("Exclusão efetuada com sucesso!");
        }
    }
}