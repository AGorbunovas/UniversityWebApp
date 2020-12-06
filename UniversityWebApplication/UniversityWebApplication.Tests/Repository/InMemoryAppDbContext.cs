using System;
using Microsoft.EntityFrameworkCore;

namespace UniversityWebApplication.Tests.Repository
{
    internal static class InMemoryAppDbContext
    {
        internal static AppDbContext GetInMemoryAppDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            return context;
        }
    }
}
