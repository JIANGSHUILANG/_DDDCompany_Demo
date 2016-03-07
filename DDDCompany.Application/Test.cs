using DDDCompany.Infrastructure.MEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using DDDCompany.Domain.IRepositories;
using DDDCompany.Domain.EFModel;
using DDDCompany.Application.IService;
using DDDCompany.Application.Service;
using DDDCompany.DtoModel.Model;
namespace DDDCompany.Application
{
    class Test
    {
        [Import]
        public IUserRepository userRepository { get; set; }

        static void Main(string[] args)
        {
          
            //var users = test.userRepository.Entites.ToList(); //查询所有的

            //User user = new User();
            //user.Name = "刘邦";
            //user.Status = true;
            //user.Cell = "110";
            //int i = test.userRepository.Add(user);

            //int z = test.userRepository.Delete(5);
            //IQueryable<User> users = test.userRepository.GetUsers_Role(1);

            //foreach (var user in users)
            //{
            //    Role role = user.Role;
            //}
            var test = new Test();
            Register.regisgter().ComposeParts(test);
            //Bootstrapper boot = new Bootstrapper();
            //boot.Start_Services();

            IPowerManageWCFService power = new PowerManageWCFService();
            List<DTO_User> list = power.Get__AllUser();
            Console.ReadKey();
        }
    }
}
