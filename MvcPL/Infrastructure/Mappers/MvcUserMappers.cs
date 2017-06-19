using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DTO;
using MvcPL.Models.UserModel;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcUserMappers
    {
        public static UserViewModel ToUserViewModel(this UserEntity entity)
        {
            return new UserViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                RoleId = entity.RoleId,
                Email = entity.Email,
                Password = entity.Password,
                Photo = entity.Photo
            };

        }

        public static UserEntity ToBllUserMOdel(this UserViewModel entity)
        {
            return new UserEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                RoleId = entity.RoleId,
                Email = entity.Email,
                Password = entity.Password,
                Photo = entity.Photo
            };

        }
    }
}