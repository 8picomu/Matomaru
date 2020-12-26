using System;
using UnityEngine;
using UniRx;

namespace Matomaru.Main {

    public interface IInputObservables {
        IObservable<Vector2> LStickObservable { get; }
        IObservable<Unit> RightClickObservable { get; }
    }
}
