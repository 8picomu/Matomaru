using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using pf35301.Extensions;

namespace Matomaru.Main {
    //[ExecuteInEditMode]
    public class PixelBuilder : MonoBehaviour, IPixelCanvas {

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

        [SerializeField]
        private PixelCanvasData m_CanvasData;

        [Header("AutoBuild")]
        [SerializeField]
        private bool m_IsAutoBuild;

        [SerializeField]
        private uint m_CanvansIncludingPixel;

        private void Awake() { 
            if(m_IsAutoBuild == false) {
                if(m_CanvasData == null) throw new NullReferenceException();

                Canvas = new List<PixelCanvasListWrapper>(m_CanvasData.Canvas);

                return;
            }
        }

        private void Start() {
            //if(Dot == null) throw new NullReferenceException();

            if(CanvasXSize % 2 != 0) {
                Debug.LogError("Please set odd in CanvasXSize");
                return;
            }
            if(CanvasYSize % 2 != 0) {
                Debug.LogError("Please set odd in CanvasYSize");
                return;
            }


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
                    }
                }
            }
        }
    }

    [Serializable]
    public class PixelCanvasListWrapper : ListWrapper<bool> { }
}