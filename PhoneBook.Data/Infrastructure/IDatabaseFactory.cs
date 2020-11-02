using System;

namespace PhoneBook.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PhoneBookDbContext GetDbContext();
    }
}
