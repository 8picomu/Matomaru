using System.Collections.Generic;

namespace Matomaru.Main {
    public interface IPixelBreaker : IClickable {

        List<ISetup> ISetupChildren { get; set; }
    }
}