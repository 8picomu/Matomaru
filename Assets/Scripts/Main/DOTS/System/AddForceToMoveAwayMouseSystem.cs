using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Physics;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;
using Random = Unity.Mathematics.Random;

using Matomaru.Main;

namespace Matomaru.ECS.Main {
    public class AddForceToMoveAwayFromMouseSystem : SystemBase
    {
        private EntityQuery query;

        private Random random;

        protected override void OnCreate()
        {
            query = GetEntityQuery(typeof(PhysicsVelocity), ComponentType.ReadOnly<Translation>());
            random = new Random(123);
        }

        protected override void OnUpdate()
        {
            var pos = Camera.main.ScreenToWorldPoint(InputProvider.MousePosition);

            var job = new AddForceToMoveAwayFromMouseJob {
                physicsVelocityType = GetComponentTypeHandle<PhysicsVelocity>(),
                translationType = GetComponentTypeHandle<Translation>(),
                mousePos = pos,
                random = random,
            };

            Dependency = job.Schedule(query, Dependency);
        }

        [BurstCompile]
        private struct AddForceToMoveAwayFromMouseJob : IJobChunk
        {
            public ComponentTypeHandle<PhysicsVelocity> physicsVelocityType;

            [ReadOnly]
            public ComponentTypeHandle<Translation> translationType;

            public float3 mousePos;
            public Random random;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var physicsVelocities = chunk.GetNativeArray(physicsVelocityType);
                var translations = chunk.GetNativeArray(translationType);

                for(var i = 0; i < chunk.Count; i++) {
                    if(math.distance(translations[i].Value, mousePos) < 50) {
                        var rndValue = random.NextFloat(1.0f, 10.0f);
                        physicsVelocities[i] = new PhysicsVelocity { Linear = new float3((mousePos.x - translations[i].Value.x) * rndValue, (mousePos.y - translations[i].Value.y) * rndValue, 0) };
                    }
                }
            }
        }
    }
}