﻿using System;
using UnityEngine;

namespace Matomaru.Main {
    public interface IInputObservables {
        IObservable<Vector2> LStickObservable { get; }
        IObservable<Vector2> RightClickObservable { get; }
    }
}
