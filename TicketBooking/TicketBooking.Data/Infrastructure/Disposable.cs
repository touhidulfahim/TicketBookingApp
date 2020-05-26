using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Data.Infrastructure
{
    public class Disposable:IDisposable
    {
        private bool m_isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!m_isDisposed && disposing)
            {
                DisposeCore();
            }

            m_isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
