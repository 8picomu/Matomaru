using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pf35301.Extensions.Editor;

namespace Matomaru.Main {
    public class PixelBuilder : MonoBehaviour {

        [SerializeField]
        private uint m_CanvasXSize;
        [SerializeField]
        private uint m_CanvasYSize;

        [SerializeField]
        private uint m_CanvansIncludingPixel;

        private void OnValidate() {

        }

        private void OnEnable() {

        }
    }
}