using Unity.Transforms;
using Unity.Entities;
using Unity.Physics;
using Unity.Jobs;
using Unity.Collections;

using UnityEngine;
using Random = Unity.Mathematics.Random;
using Matomaru.Main;

namespace Matomaru.ECS.Main {
    class MovePixelSystem : SystemBase {

        private EntityQuery query;

        private uint seed = 1;

        protected override void OnCreate()
        {
            query = GetEntityQuery(ComponentType.ReadOnly<PhysicsVelocity>(), typeof(Translation));
        }

        protected override void OnUpdate() {

            var pos = Camera.main.ScreenToWorldPoint(InputProvider.MousePosition);

            var entitesCount = query.CalculateEntityCount();

            var rndNumbers = new NativeArray<float>(entitesCount, Allocator.TempJob);

            var rnd = new Random(seed++);
            Job.WithCode(() => {
                for(int i = 0; i < rndNumbers.Length; i++) {
                    rndNumbers[i] = rnd.NextFloat(1.0f, 10.0f);
                }
            })
            .Schedule();

            Entities
                .ForEach((int entityInQueryIndex, ref PhysicsVelocity physicsVelosity, in Translation translation) => {

                    var value = rndNumbers[entityInQueryIndex];

                    physicsVelosity.Linear.x = (pos.x - translation.Value.x) * value;
                    physicsVelosity.Linear.y = (pos.y - translation.Value.y) * value;
            })
            .WithDisposeOnCompletion(rndNumbers)
            .Schedule();
        }
    }
}
