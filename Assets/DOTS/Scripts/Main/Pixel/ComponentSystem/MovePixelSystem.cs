using Unity.Transforms;
using Unity.Entities;
using Unity.Physics;
using Unity.Jobs;

using UnityEngine;
using Matomaru.Main;

namespace Matomaru.ECS.Main {
    class MovePixelSystem : SystemBase {

        protected override void OnUpdate() {

            var pos = Camera.main.ScreenToWorldPoint(InputProvider.MousePosition);

            Entities
                .ForEach((ref PhysicsVelocity physicsVelosity, in Translation translation) => {
                    var value = Random.Range(1.0f, 10.0f);

                    physicsVelosity.Linear.x = (pos.x - translation.Value.x) * value;
                    physicsVelosity.Linear.y = (pos.y - translation.Value.y) * value;
            }).Run();
        }
    }
}
