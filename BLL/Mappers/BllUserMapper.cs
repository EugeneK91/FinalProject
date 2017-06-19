using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using Entity;

namespace BLL.Mappers
{
    public static class BllUserMapper
    {
        public static UserEntity ToBllUser(this User user)
        {
            if (user == null) return null;
            return new UserEntity
            {
                Id = user.Id,
                RoleId = user.RoleId,
                Name = user.Name,
                Password = user.Password,
                Photo = user.Photo,
                Email = user.Email
            };
        }

        public static User ToDalUser(this UserEntity userEntity)
        {
            if (userEntity == null)return null;
            return new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Photo = userEntity.Photo,
                RoleId = userEntity.RoleId
            };
        }
    }
}
