using Leap;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxLeapMotion
{
    internal class RxListener : Listener
    {
        public IObservable<Controller> ConnectObservable     => connect.AsObservable();
        public IObservable<Controller> DisconnectObservable  => disconnect.AsObservable();
        public IObservable<Controller> InitObservable        => init.AsObservable();
        public IObservable<Controller> ExitObservable        => exit.AsObservable();
        public IObservable<Controller> FocusGainedObservable => focusGained.AsObservable();
        public IObservable<Controller> FocusLostObservable   => focusLost.AsObservable();
        public IObservable<Frame>      FrameObservable       => frame.AsObservable();

        private Subject<Controller> connect     = new Subject<Controller>();
        private Subject<Controller> disconnect  = new Subject<Controller>();
        private Subject<Controller> init        = new Subject<Controller>();
        private Subject<Controller> exit        = new Subject<Controller>();
        private Subject<Controller> focusGained = new Subject<Controller>();
        private Subject<Controller> focusLost   = new Subject<Controller>();
        private Subject<Frame>      frame       = new Subject<Frame>();

        public override void OnConnect(Controller controller)
        {
            if (connect.IsDisposed == false && controller != null)
            {
                connect.OnNext(controller);
            }
        }

        public override void OnDisconnect(Controller controller)
        {
            if (disconnect.IsDisposed == false && controller != null)
            {
                disconnect.OnNext(controller);
            }
        }

        public override void OnInit(Controller controller)
        {
            if (init.IsDisposed == false && controller != null)
            {
                init.OnNext(controller);
            }
        }

        public override void OnExit(Controller controller)
        {
            if (exit.IsDisposed == false && controller != null)
            {
                exit.OnNext(controller);
            }
        }

        public override void OnFocusGained(Controller controller)
        {
            if (focusGained.IsDisposed == false && controller != null)
            {
                focusGained.OnNext(controller);
            }
        }

        public override void OnFocusLost(Controller controller)
        {
            if (focusLost.IsDisposed == false && controller != null)
            {
                focusLost.OnNext(controller);
            }
        }

        public override void OnFrame(Controller controller)
        {
            if (frame.IsDisposed == false && controller != null && controller.Frame() != null)
            {
                frame.OnNext(controller.Frame());
            }
        }
    }
}
