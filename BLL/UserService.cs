using BLL.Interfaces;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserService:IUserService
    {

        // not part of exercice, created in video tutorial

        // 
        // !!!!Vergeet de startup file niet aan te passen! 
        //

        /*UserRepository repository;

        public UserService()
        {
            repository = new UserRepository();
        }
        */


        IUserRepository repository;

        public UserService(IUserRepository _repository)
        {
            repository = _repository;
        }

        public List<User> GetAllUsers() 
        {
            return repository.Get();
        }

        public void Save(User user)
        {
            repository.Save(user);
        }
    }
}
