using System.Collections.Generic;

namespace Matomaru.Main {
    public interface IPixelBreaker : IClickable {

        List<IIndependentPixel> ISetupChildren { get; set; }
    }
}