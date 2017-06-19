using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interface;

namespace BLL.Interface
{
    public interface IUserService
    {
        UserEntity GetUserByEmail(string email);
        void CreateUser(UserEntity userEntity);
        IEnumerable<UserEntity> GetAllUsers();
        void UpdateUser(UserEntity model);
        void Delete(int id);
    }
}
