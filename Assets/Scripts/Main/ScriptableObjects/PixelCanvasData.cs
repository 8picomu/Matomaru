using System;
using System.Collections.Generic;
using UnityEngine;

using eightpicomu.Extensions;

namespace Matomaru.Main {

    [CreateAssetMenu(menuName = "ScriptableObject/PixelCanvasData")]
    public class PixelCanvasData : ScriptableObject, IPixelCanvas {
        public List<PixelCanvasArrayWrapper> m_Canvas;

        public List<PixelCanvasArrayWrapper> Canvas { get => m_Canvas; set => m_Canvas = value; }

        public int CanvasXSize;

        public int CanvasYSize;
    }

    
    [Serializable]
    public class PixelCanvasArrayWrapper : BoolArrayWrapper { }
}