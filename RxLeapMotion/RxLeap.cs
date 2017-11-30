using Leap;
using System;

namespace RxLeapMotion
{
    public class RxLeap : IRxLeap, IDisposable
    {
        public IObservable<Controller> Connect      => listener.ConnectObservable;
        public IObservable<Controller> Disconnect   => listener.DisconnectObservable;
        public IObservable<Controller> Init         => listener.InitObservable;
        public IObservable<Controller> Exit         => listener.ExitObservable;
        public IObservable<Controller> FocusGained  => listener.FocusGainedObservable;
        public IObservable<Controller> FocusLost    => listener.FocusLostObservable;
        public IObservable<Frame> Frame             => listener.FrameObservable;

        private RxListener listener = new RxListener();
        private Controller controller = new Controller();

        public RxLeap()
        {
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
