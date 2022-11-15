using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersWritersProblem
{
    public abstract class CustomMonitor
    {
        private bool _isWriting;
        private int _readersCount = 0;
        private int _waitingWritersCount = 0;
        private int _waitingReadersCount = 0;

        private readonly object _readLock = new object();  
        private readonly object _writeLock = new object();

        protected void StartRead()
        {
            lock (_readLock)
            {
                // A reader can enter if there are no writers
                // active or waiting, so we can have
                // many readers active all at once
                if (_isWriting || _waitingWritersCount > 0)
                {
                    _waitingReadersCount++;

                    // Otherwise, a reader waits (maybe many do)
                    Monitor.Wait(_readLock);

                    _waitingReadersCount--;
                }

                _readersCount++;
                Monitor.Pulse(_readLock);
            }
        }

        protected void EndRead()
        {
            lock(_writeLock)
            {
                _readersCount--;

                // When a reader finishes, if it was the last reader,
                // it lets a writer in (if any is there).
                if (_readersCount == 0)
                    Monitor.Pulse(_writeLock);
            }
        }

        protected void StartWrite()
        {
            // A writer can enter if there are no other
            // active writers and no readers are waiting
            lock(_writeLock)
            {
                if(_readersCount > 0 || _isWriting)
                {
                    _waitingWritersCount++;

                    Monitor.Wait(_writeLock);

                    _waitingWritersCount--;
                }

                _isWriting = true;
            }
        }

        protected void EndWrite()
        {
            _isWriting = false;

            if (_waitingReadersCount > 0)
            {
                lock (_readLock)
                {
                    Monitor.Pulse(_readLock);
                }
            }
            else
            {
                lock (_writeLock)
                {
                    Monitor.Pulse(_writeLock);
                }
            }
        }

    }
}
