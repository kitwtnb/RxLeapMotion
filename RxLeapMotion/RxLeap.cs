using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxLeapMotion
{
    public class RxLeap : IDisposable
    {
        private RxListener listener;
        private Controller controller;

        public RxLeap()
        {
            listener = new RxListener();
            controller = new Controller();
            controller.AddListener(listener);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    controller.RemoveListener(listener);
                    controller.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
