using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Gateway;

namespace TicketBooking.Data.Infrastructure
{
    public class RepositoryBase<T>: Disposable, IRepository<T> where T:class
    {
        private readonly TicketBookingDbContext _context;
       

        string errorMessage = string.Empty;

        private IDbSet<T> Dbset
        {
            get { return _context.Set<T>(); }
        }
        
        public RepositoryBase(TicketBookingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset.AsEnumerable();
        }

        public T GetById(int? id)
        {
            return Dbset.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Dbset.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Dbset.Remove(entity);
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Dbset.Remove(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

       
    }
}
