using System;
using System.Collections.Generic;
using System.Linq;
using NOWA.Models;

namespace NOWA.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {

        private readonly NOWAContext context;
        private bool disposed = false;

        public UserRepository(NOWAContext context)
        {
            this.context = context;
        }

        public void InsertUser(User newUser)
        {
            context.User.Add(newUser);
        }

        public User GetUserById(int idUser)
        {
            return context.User.Where(u => u.Id == idUser).FirstOrDefault();
        }

        public List<User> GetUserList()
        {
            return context.User.ToList();
        }

        // TODO
        public void UpdateUser(User userToUpdate)
        {
            throw new System.NotImplementedException();
        }

        // TODO
        public void DeleteUser(int idUser)
        {
            throw new System.NotImplementedException();
        }


        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}