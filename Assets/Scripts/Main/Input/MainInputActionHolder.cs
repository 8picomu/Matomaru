using UnityEngine;
using UnityEngine.InputSystem;

namespace Matomaru.Main {
    class MainInputActionHolder : MonoBehaviour {

        private MainInputAction m_Input;

        private void Awake() {
            m_Input = new MainInputAction();
            m_Input.Player.SetCallbacks(
                GetComponent<MainInputAction.IPlayerActions>()
                );
        }

        private void OnEnable() {
            m_Input.Enable();
        }

        private void OnDisable() {
            m_Input.Disable();
        }

        private void OnDestroy() {
            m_Input.Dispose();
        }
    }
}
