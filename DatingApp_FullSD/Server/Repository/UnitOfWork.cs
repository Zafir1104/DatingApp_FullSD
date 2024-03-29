﻿using DatingApp_FullSD.Server.Data;
using DatingApp_FullSD.Server.IRepository;
using DatingApp_FullSD.Server.Models;
using DatingApp_FullSD.Server.Repository;
using DatingApp_FullSD.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatingApp_FullSD.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Profile> _profiles;
        private IGenericRepository<Match> _matches;
        private IGenericRepository<Post> _posts;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IGenericRepository<Profile> Profiles
            => _profiles ??= new GenericRepository<Profile>(_context);
        public IGenericRepository<Match> Matches
            => _matches ??= new GenericRepository<Match>(_context);
        public IGenericRepository<Post> Posts
            => _posts ??= new GenericRepository<Post>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}