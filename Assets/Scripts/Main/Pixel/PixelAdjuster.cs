using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Matomaru.Main {
    public class PixelAdjuster : MonoBehaviour, IPixelAdjuster {
        private Vector3 m_cashPosition;

        public void PixelAdjust() {
            m_cashPosition = transform.localPosition;

            transform.localPosition = new Vector3(
                Mathf.RoundToInt(m_cashPosition.x),
                Mathf.RoundToInt(m_cashPosition.y),
                Mathf.RoundToInt(m_cashPosition.z));
        }

        private void LateUpdate() {
            PixelAdjust();
        }

        private void OnRenderObject() {
            transform.localPosition = m_cashPosition;
        }
    }
}