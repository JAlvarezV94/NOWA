using System;
using System.Collections.Generic;
using NOWA.Models;

namespace NOWA.Repositories
{
    public interface IUserRepository : IDisposable
    {
        void InsertUser(User newUser);
        List<User> GetUserList();
        User GetUserById(int idUser);
        bool UserAlreadyExists(string email);
        bool UserCredentialsAreCorrect(string email, string password);
        void UpdateUser(User userToUpdate);
        void DeleteUser(int idUser);
        void Save();
    }
}