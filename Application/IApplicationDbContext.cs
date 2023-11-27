using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Student { get; }

        DbSet<Course> Course { get; }

        Task savechanges();
    }
}
