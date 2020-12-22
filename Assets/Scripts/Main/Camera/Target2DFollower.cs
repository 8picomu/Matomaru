using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Matomaru.Main {
    class Target2DFollower : MonoBehaviour {
        [SerializeField]
        private GameObject m_Target;

        private void LateUpdate() {
            if(m_Target != null) {
                var pos = m_Target.transform.position;
                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            } 
        }
    }
}