using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Helpers;
using BLL.Interface;
using BLL.Mappers;
using DAL.DTO;
using DAL.Interface;
using Entity;

namespace BLL
{
    public class UserService: IUserService
    {

        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uow, IUserRepository userRepository)
        {
            _uow = uow;
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int key)
        {
            return _userRepository.GetById(key);
        }

        public void Create(User e)
        {
            _userRepository.Create(e);
            _uow.Commit();
        }

        public void Delete(User e)
        {
            _userRepository.Delete(e);
            _uow.Commit();
        }

        public void Update(User entity)
        {
            var user = _userRepository.GetById(entity.Id);

            user.Email = entity.Email;
            user.Name = entity.Name;
            user.Password = entity.Password;
            user.Photo = entity.Photo;
            user.RoleId = entity.RoleId;

            _uow.Commit();
        }

        public UserEntity GetUserByEmail(string email)
        {
            Expression<Func<User, bool>> predicate = c => c.Email.Equals(email);
            var dalUser = _userRepository.GetFirstByPredicate(predicate);
            return dalUser.ToBllUser();
        }

        public void CreateUser(UserEntity user)
        {
            _userRepository.Create(user.ToDalUser());
            _uow.Commit();
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _userRepository.GetAll().Select(c=>c.ToBllUser());
        }

        public void UpdateUser(UserEntity model)
        {
            var entityUser = _userRepository.GetFirstByPredicate(c=>c.Email.Equals(model.Email));
            _userRepository.Update(model.ToDalUser());
            _uow.Commit();
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
            _uow.Commit();
        }
    }
}
