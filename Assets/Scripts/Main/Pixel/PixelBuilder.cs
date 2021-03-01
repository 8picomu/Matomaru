using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using eightpicomu.Extensions;

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
        public List<PixelCanvasListWrapper> Canvas { get; set; }

        [Header("AutoBuild")]
        [SerializeField]
        private bool m_IsMockBuild;

        [SerializeField]
        private uint m_CanvansIncludingPixel;

        private IPixelBreaker m_IPixelBreaker;

        public void Build() {
            if(m_CanvasData == null) throw new NullReferenceException();

            Canvas = new List<PixelCanvasListWrapper>(m_CanvasData.Canvas);

            CanvasXSize = m_CanvasData.CanvasXSize;
            CanvasYSize = m_CanvasData.CanvasYSize;

            if(m_Dot == null) throw new NullReferenceException();

            if(CanvasXSize % 2 != 0) {
                Debug.LogError("Please set odd in CanvasXSize");
                return;
            }
            if(CanvasYSize % 2 != 0) {
                Debug.LogError("Please set odd in CanvasYSize");
                return;
            }

            m_IPixelBreaker = GetComponent<IPixelBreaker>();

            foreach(var record in Canvas.Select((value, index) => new { value, index })) {
                foreach(var item in record.value.List.Select((value, index) => new { value, index })) {
                    if(item.value) {
                        var dot = Instantiate(m_Dot);
                        dot.transform.parent = transform;
                        dot.name = $"{item.index} : {record.index}";
                        dot.transform.localPosition =
                            new Vector3(item.index - (CanvasXSize / 2),
                                        (CanvasYSize / 2) - record.index,
                                        0);
                        m_IPixelBreaker?.ISetupChildren.Add(dot.GetComponent<IIndependentPixel>());
                    }
                }
            }
        }
    }

    [Serializable]
    public class PixelCanvasListWrapper : ListWrapper<bool> { }
}