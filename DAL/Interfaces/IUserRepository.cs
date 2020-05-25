using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    // not part of exercice, created in video tutorial
    public interface IUserRepository
    {
        List<User> Get();
        User FindById(int id);

        void Save(User user);

    }
}
