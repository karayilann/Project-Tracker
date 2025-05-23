using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Core.Interfaces.UnitOfWork;
using ProjectTracker.Repository.Context;

namespace ProjectTracker.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context, IGenericRepository<Project> projects, IGenericRepository<User> users, 
            IGenericRepository<WorkItem> workItem, IGenericRepository<Role> roles)
        {
            _context = context;
            Projects = projects;
            Users = users;
            WorkItem = workItem;
            Roles = roles;
        }

        public IGenericRepository<Project> Projects { get; set; }
        public IGenericRepository<User> Users { get; set; }
        public IGenericRepository<WorkItem> WorkItem { get; set; }
        public IGenericRepository<Role> Roles { get; set; }

        private readonly AppDbContext _context;

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }

    }
}
