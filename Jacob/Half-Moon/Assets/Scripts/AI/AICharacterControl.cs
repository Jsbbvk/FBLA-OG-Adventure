using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform[] points;                                    // target to aim for
        public Transform target;

        private float StationaryTimer = 0;
        [Range(1f, 5f)] public float MinStationaryTime = 4f;
        [Range(5f, 20f)] public float MaxStationaryTime = 15f;

        public int State;
        public readonly int Stationary = 0;
        public readonly int Moving = 1;
        public readonly int Talking = 2;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (State == Moving)
            {
                if (target != null)
                    agent.SetDestination(target.position);

                if (agent.remainingDistance > agent.stoppingDistance)
                    character.Move(agent.desiredVelocity, false, false);
                else
                {
                    character.Move(Vector3.zero, false, false);
                    State = Stationary;
                }
            }
            if (State == Stationary)
            {
                StationaryTimer += Time.deltaTime;
                if (StationaryTimer > UnityEngine.Random.Range(MinStationaryTime, MaxStationaryTime))
                {
                    State = Moving;
                    StationaryTimer = 0;
                    Transform t = points[UnityEngine.Random.Range(0, points.Length)];
                    while (t.Equals(target))
                    {
                        t = points[UnityEngine.Random.Range(0, points.Length)];
                    }
                    target = t;
                }
                character.Move(Vector3.zero, false, false);
                //transform.Rotate(new Vector3(5f, 0f));
            }
           
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
