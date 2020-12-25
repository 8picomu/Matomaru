using System.Collections.Generic;

namespace Matomaru.Main {
    public interface IPixelCanvas {
        List<PixelCanvasListWrapper> Canvas { get; set; }
    }
}