using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Matomaru.Main {
    [ExecuteInEditMode]
    public class PixelBuilder : MonoBehaviour {

        [Header("Canvas")]

        [SerializeField]
        private int m_CanvasXSize;
        [SerializeField]
        private int m_CanvasYSize;

        //[X][Y]
        [SerializeField]
        public bool[][] Canvas;

        [Header("AutoBuild")]
        [SerializeField]
        private bool m_IsAutoBuild;

        [SerializeField]
        private uint m_CanvansIncludingPixel;

        private void OnValidate() {
            Canvas = Enumerable.Range(0, m_CanvasYSize).Select(y => (new bool[m_CanvasXSize]).Select(x => true).ToArray()).ToArray();
        }

        private void OnEnable() {

        }
    }
}