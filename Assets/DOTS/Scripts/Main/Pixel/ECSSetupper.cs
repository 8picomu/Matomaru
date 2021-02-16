using UnityEngine;
using Unity.Entities;

using Matomaru.Main;

namespace Matomaru.ECS.Main {

    class ECSSetupper : MonoBehaviour, IClickable {
        public void ClickWithHitPoint(Vector2 hitPoint) {
            SetUp();
        }

        public void SetUp() {
            gameObject.AddComponent<ConvertToEntity>();
        }
    }
}
