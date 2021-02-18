using Unity.Entities;
using Unity.Physics;
using Unity.Jobs;

namespace Matomaru.ECS.Main {
    class MovePixelSystem : ComponentSystem {

        protected override void OnCreate() {

        }

        protected override void OnUpdate() {
            Entities
                .ForEach((ref PhysicsVelocity physicsVelosity) => {
                physicsVelosity.Linear.x = 10.0f;
            });
        }
    }
}
