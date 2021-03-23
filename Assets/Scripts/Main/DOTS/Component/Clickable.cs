using Unity.Entities;

namespace Matomaru.ECS.Main {
    public struct Clickable : IComponentData {
        public bool isClicked;
    }
}