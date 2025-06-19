using Adventures.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Infrastructure
{
    public interface IUnitOfWork
    {
        GenericRepository<Trip> TripRepository { get; }

        void Save();


    }
}
