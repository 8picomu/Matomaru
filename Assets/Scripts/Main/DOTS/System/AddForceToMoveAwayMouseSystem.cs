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
            query = GetEntityQuery(typeof(PhysicsVelocity), ComponentType.ReadOnly<Translation>(), );
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
                    physicsVelocities[i] = new PhysicsVelocity { Linear = (translations[i].Value - mousePos) * random.NextFloat(0.1f, 1.0f) };
                }
            }
        }
    }
}