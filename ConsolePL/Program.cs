using BLL.Interface;
using DependencyResolver;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePL
{
    class Program
    {
        public static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<IUserService>();
            var users = service.GetAllUsers().ToList();
            for  (var i = 0;i< users.Count();i++)
            {
                Console.WriteLine("User #" + i);
                Console.WriteLine($"id: {users[i].Id}, Name: {users[i].Name}, Email: {users[i].Email}");
            }
        }
    }
}
