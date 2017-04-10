using Leap;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxLeapMotion
{
    public class RxListener : Listener
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
            if (connect.IsDisposed == false)
            {
                connect.OnNext(controller);
            }
        }

        public override void OnDisconnect(Controller controller)
        {
            if (disconnect.IsDisposed == false)
            {
                disconnect.OnNext(controller);
            }
        }

        public override void OnInit(Controller controller)
        {
            if (init.IsDisposed == false)
            {
                init.OnNext(controller);
            }
        }

        public override void OnExit(Controller controller)
        {
            if (exit.IsDisposed == false)
            {
                exit.OnNext(controller);
            }
        }

        public override void OnFocusGained(Controller controller)
        {
            if (focusGained.IsDisposed == false)
            {
                focusGained.OnNext(controller);
            }
        }

        public override void OnFocusLost(Controller controller)
        {
            if (focusLost.IsDisposed == false)
            {
                focusLost.OnNext(controller);
            }
        }

        public override void OnFrame(Controller controller)
        {
            if (frame.IsDisposed == false)
            {
                frame.OnNext(controller.Frame());
            }
        }
    }
}
