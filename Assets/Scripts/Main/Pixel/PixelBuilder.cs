using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Matomaru.Main {
    public class PixelBuilder : MonoBehaviour, IPixelCanvas {

        [Header("CanvasData")]

        [SerializeField]
        private PixelCanvasData m_CanvasData;

        [Header("Dot")]

        [SerializeField]
        private GameObject m_Dot;

        [Header("Canvas")]

        [SerializeField]
        public int CanvasXSize;
        [SerializeField]
        public int CanvasYSize;

        //[Y][X]
        [SerializeField]
        public List<PixelCanvasArrayWrapper> Canvas { get => m_CanvasData.Canvas; set => m_CanvasData.Canvas = value; }

        [Header("AutoBuild")]
        [SerializeField]
        private bool m_IsMockBuild;

        [SerializeField]
        private uint m_CanvansIncludingPixel;


        public void Build() {
            if(m_CanvasData == null) throw new NullReferenceException();

            CanvasXSize = m_CanvasData.CanvasXSize;
            CanvasYSize = m_CanvasData.CanvasYSize;

            if(m_Dot == null) throw new NullReferenceException();


            foreach(var record in Canvas.Select((value, index) => new { value, index })) {
                foreach(var item in record.value.Array.Select((value, index) => new { value, index })) {
                    if(item.value) {
                        var dot = Instantiate(m_Dot);
                        dot.transform.parent = transform;
                        dot.name = $"{item.index} : {record.index}";
                        dot.transform.localPosition =
                            new Vector3(item.index - (CanvasXSize / 2),
                                        (CanvasYSize / 2) - record.index,
                                        0);
                    }
                }
            }
        }
    }
}