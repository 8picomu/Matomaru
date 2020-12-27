using System;
using UnityEngine;
using UniRx;

namespace Matomaru.Main {
    public class TargetClickSender : MonoBehaviour {
        private IInputObservables m_InputObservables;

        private void Start() {
            m_InputObservables = ServiceLocatorProvider.Instance.Current.Resolve<IInputObservables>();

            m_InputObservables.RightClickObservable.Subscribe(mousePos => {
                var ray = Camera.main.ScreenPointToRay(mousePos);
                var hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                if(hit) {
                    hit.transform.GetComponent<IClickable>()?.Click();
                }
            });
        }
    }
}