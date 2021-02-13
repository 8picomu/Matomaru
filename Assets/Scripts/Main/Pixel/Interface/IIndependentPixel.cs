
using UnityEngine;

namespace Matomaru.Main {
    public interface IIndependentPixel : IPixelFollow {

        bool IsIndependent { get; }

        void Setup(Vector2 hitPoint);
    }
}