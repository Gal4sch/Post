using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Core.Repositories;

namespace Post.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>();

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(int userNumber)
            => await Task.FromResult(_users.SingleOrDefault(x => x.UserNumber == userNumber));

        public async Task<User> GetAsync(string userLogin)
            => await Task.FromResult(_users.SingleOrDefault(x => 
            x.UserLogin.ToLowerInvariant() == userLogin.ToLowerInvariant()));

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }
    }
}