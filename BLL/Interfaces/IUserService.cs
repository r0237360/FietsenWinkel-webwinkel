using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{

    // not part of exercice, created in video tutorial
    public interface IUserService
    {

        List<User> GetAllUsers();

        void Save(User user);


    }
}
