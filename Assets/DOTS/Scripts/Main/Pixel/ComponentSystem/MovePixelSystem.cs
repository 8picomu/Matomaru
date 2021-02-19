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
                    var value = Random.Range(300.0f, 400.0f);

                    var positionVector = new Vector3(translation.Value.x, translation.Value.y, translation.Value.z);

                    var direction = (pos - positionVector).normalized;

                    physicsVelosity.Linear.x = direction.x * value;
                    physicsVelosity.Linear.y = direction.y * value;
            }).Run();
        }
    }
}
