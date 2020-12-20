using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Matomaru.Main {
    public class PixelAdjuster : MonoBehaviour {
        private Vector3 m_cashPosition;

        private void LateUpdate() {
            m_cashPosition = transform.localPosition;

            transform.localPosition = new Vector3(
                Mathf.RoundToInt(m_cashPosition.x), 
                Mathf.RoundToInt(m_cashPosition.y), 
                Mathf.RoundToInt(m_cashPosition.z)
                );
        }

        private void OnRenderObject() {
            transform.localPosition = m_cashPosition;
        }
    }
}