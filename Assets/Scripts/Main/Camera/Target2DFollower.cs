using UnityEngine;

namespace Matomaru.Main {
    class Target2DFollower : MonoBehaviour {
        [SerializeField]
        private GameObject m_Target;

        [SerializeField]
        private Vector2 m_Offset;

        private void LateUpdate() {
            if(m_Target != null) {
                var pos = m_Target.transform.position;
                transform.position = new Vector3(pos.x + m_Offset.x, pos.y + m_Offset.y, transform.position.z);
            } 
        }
    }
}