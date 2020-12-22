using UnityEngine;
using System;

namespace Matomaru.Main {

    public interface IInputObservables {
        IObservable<Vector2> LStickObservable { get; }
    }
}
