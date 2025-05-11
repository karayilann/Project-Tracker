using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Repository.Context;
using Task = ProjectTracker.Core.Entities.Task;

namespace ProjectTracker.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context, IGenericRepository<Project> projects, IGenericRepository<User> users, 
            IGenericRepository<Task> tasks, IGenericRepository<Role> roles)
        {
            _context = context;
            Projects = projects;
            Users = users;
            Tasks = tasks;
            Roles = roles;
        }

        public IGenericRepository<Project> Projects { get; set; }
        public IGenericRepository<User> Users { get; set; }
        public IGenericRepository<Task> Tasks { get; set; }
        public IGenericRepository<Role> Roles { get; set; }

        private readonly AppDbContext _context;

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }

    }
}
