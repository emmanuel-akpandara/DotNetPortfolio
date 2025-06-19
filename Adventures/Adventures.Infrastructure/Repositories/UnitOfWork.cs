using Adventures.Domain.Models;
using Adventures.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private TravelContext _context;
        private GenericRepository<Trip> tripRepository;
        public UnitOfWork(TravelContext context)
        {
            _context = context;
        }

        public void Save()
        {

            _context.SaveChanges();
        }

        public GenericRepository<Trip> TripRepository
        {

            get
            {
                if (tripRepository == null)
                {

                    tripRepository = new GenericRepository<Trip>(_context);
                }
                return tripRepository;
            }

        }


    }
}
