using GameProject.Server.IRepository;
using GamesProject.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<AgeRating> AgeRatings { get; }
        IGenericRepository<Game> Games { get; }
        IGenericRepository<GamePublisher> GamePublishers { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Customer> Customers { get; }
    }
}