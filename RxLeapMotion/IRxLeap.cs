using Leap;
using System;

namespace RxLeapMotion
{
    public interface IRxLeap
    {
        IObservable<Controller> Connect { get; }
        IObservable<Controller> Disconnect { get; }
        IObservable<Controller> Init { get; }
        IObservable<Controller> Exit { get; }
        IObservable<Controller> FocusGained { get; }
        IObservable<Controller> FocusLost { get; }
        IObservable<Frame> Frame { get; }
    }
}
