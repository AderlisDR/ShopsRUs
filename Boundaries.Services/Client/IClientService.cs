using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boundaries.Services.Client
{
    /// <summary>
    /// Represents a contract for <see cref="User"/> services.
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Retrieves all the clients.
        /// </summary>
        /// <returns>An instance of <see cref="Task{IList{User}}"/>.</returns>
        Task<IList<User>> GetAllAsync();

        /// <summary>
        /// Inserts a new client.
        /// </summary>
        /// <param name="user">An instance of <see cref="User"/>.</param>
        /// <returns>An instance of <see cref="Task"/>.</returns>
        Task CreateAsync(User user);

        /// <summary>
        /// Retrieves a client by its id.
        /// </summary>
        /// <param name="id">The client id.</param>
        /// <returns>An instance of <see cref="Task{User}"/>.</returns>
        Task<User> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves a client by its name.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <returns>AN instance of <see cref="User"/>.</returns>
        User GetByName(string name);
    }
}
