using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pf35301.Extensions.Editor;

namespace Matomaru.Main {
    public class PixelBuilder : MonoBehaviour {

        [Header("DotsParent")]

        [SerializeField]
        private GameObject m_dotsParent;

        [SerializeField, Tag]
        private string m_dotsTag = "DotsParent";

        [SerializeField, ReadOnly]
        private string m_dotsParentName = "DotsParent";

        [Header("Dots")]

        [SerializeField]
        private GameObject m_Dot;

        private void OnValidate() {
            if(m_dotsParent == null) {
                var haveDotsObject = false;
                foreach(Transform item in transform) {
                    if(item.CompareTag(m_dotsTag)) {
                        haveDotsObject = true;
                        m_dotsParent = item.gameObject;
                        break;
                    }
                }

                if(haveDotsObject == false) {
                    var obj = new GameObject();
                    m_dotsParent = Instantiate(obj);
                }

                m_dotsParent.transform.parent = transform;
                m_dotsParent.name = m_dotsParentName;
                m_dotsParent.tag = m_dotsTag;
            }
        }

        private void OnEnable() {

        }
    }
}