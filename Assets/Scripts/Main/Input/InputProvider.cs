using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using eightpicomu.Extensions.Editor;

namespace Matomaru.Main {

    public class InputProvider : SingletonMonoBehaviour<InputProvider>, IInputObservables, MainInputAction.IPlayerActions {
        
        public IObservable<Vector2> LStickObservable { get => m_LStickSubject; }
        private ISubject<Vector2> m_LStickSubject;
        [SerializeField, ReadOnly]
        public Vector2 m_LStickValue = new Vector2();

        public IObservable<Vector2> RightClickObservable { get => m_RightClickSubject; }
        private ISubject<Vector2> m_RightClickSubject;

        [SerializeField, ReadOnly]
        public static Vector2 MousePosition = new Vector2();

        private void Awake() {
            m_LStickSubject = new LStick();
            m_RightClickSubject = new RightClickSubject();
            ServiceLocatorProvider.Instance.Current.Register<IInputObservables>(this);
        }

        private void FixedUpdate() {
            m_LStickSubject.OnNext(m_LStickValue.normalized);
        }

        private void OnDestroy() {
            m_LStickSubject.OnCompleted();
        }

        public void OnXAxis(InputAction.CallbackContext context) {
            if(context.performed) {
                m_LStickValue.x = context.ReadValue<float>();
            }
        }

        public void OnYAxis(InputAction.CallbackContext context) {
            if(context.performed) {
                m_LStickValue.y = context.ReadValue<float>();
            }
        }

        public void OnClick(InputAction.CallbackContext context) {
            if(context.performed) {
                m_RightClickSubject.OnNext(MousePosition);
            }
        }

        public void OnMousePosition(InputAction.CallbackContext context) {
            if(context.performed) {
                MousePosition = context.ReadValue<Vector2>();
            }
        }
    }

    internal class LStick : Subject<Vector2> { }

    internal class RightClickSubject : Subject<Vector2> { }
}