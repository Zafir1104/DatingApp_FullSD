using DatingApp_FullSD.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp_FullSD.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Profile> Profiles { get; }
        IGenericRepository<Match> Matches { get; }
        IGenericRepository<Post> Posts { get; }
    }
}