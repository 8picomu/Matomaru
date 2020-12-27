using System.Collections.Generic;

namespace Matomaru.Main {
    public interface IPixelBreaker : IClickable {

        List<IClickable> IClickableChildren { get; set; }
    }
}