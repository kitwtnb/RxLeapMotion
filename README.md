# RxLeapMotion

## Description
This library supports Leap Motion Controller using Reactive Extensions.

## Installation
1. Add reference.
    * `RxLeapMotion.dll`
    * `LeapSDK/lib/x64/LeapCSharp.NET4.0.dll`
1. Install `System.Reactive` on Nuget.
1. Place in exe directory.
    * `LeapSDK/lib/x64/Leap.dll`
    * `LeapSDK/lib/x64/LeapCSharp.dll`

## Exapmle

```
class Program
{
    static void Main(string[] args)
    {
        var leap = new Controller();
        var listener = new RxListener();
        var disposer = listener.FrameObservable
                               .Where(frame => frame != null)
                               .Subscribe(frame => Console.WriteLine(frame.Fingers[0].TipPosition.x));
        leap.AddListener(listener);

        Console.Read();

        leap.RemoveListener(listener);
        disposer.Dispose();
    }
}

```
