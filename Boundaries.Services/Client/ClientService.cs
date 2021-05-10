using Boundaries.Persistence;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boundaries.Services.Client
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientService : IClientService
    {
        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public ClientService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        ///<inheritdoc/>
        public async Task CreateAsync(User user)
        {
            if (_userRepository.Table.FirstOrDefault(u => u.Name == user.Name) != null) throw new Exception($"Client with name {user.Name} already registered.");
            user.CreatedOnUtc = DateTime.UtcNow;
            if (user.IsAffiliated) user.AffiliatedOnUtc = DateTime.UtcNow;
            await _userRepository.InsertAsync(user);
        }

        ///<inheritdoc/>
        public Task<IList<User>> GetAllAsync() => _userRepository.GetAllAsync();

        ///<inheritdoc/>
        public Task<User> GetByIdAsync(int id)
        {
            if (id == 0) throw new Exception("Invalid user ID.");
            return _userRepository.GetByIdAsync(id);
        }

        ///<inheritdoc/>
        public User GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Invalid client name.");
            return _userRepository.Table.FirstOrDefault(user => user.Name == name);
        }
    }
}
