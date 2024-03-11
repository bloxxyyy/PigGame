using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAnimal : MonoBehaviour
{
    [SerializeField]
    private Transform[] targetPositions;

    [SerializeField]
    private NavMeshAgent agent;

    public int CurrentTargetIndex { get; set; } = -1;

    private void Start()
    {
        if (agent == null || targetPositions.Length == 0)
        {
            Debug.LogError("Agent or target positions not set properly.");
            return;
        }

        MoveToNextTarget();
    }

    private void MoveToNextTarget()
    {
        if (CurrentTargetIndex == -1) return;

        if (CurrentTargetIndex < targetPositions.Length)
        {
            agent.SetDestination(targetPositions[CurrentTargetIndex].position);
        }
    }

    public void SetDestinationBasedOnNeeds(AnimalNeeds needs)
    {
        switch (needs)
        {
            case AnimalNeeds.Hungry:
                CurrentTargetIndex = 0;
                MoveToNextTarget();
                break;
            case AnimalNeeds.Sleepy:
                CurrentTargetIndex = 1;
                MoveToNextTarget();
                break;
            case AnimalNeeds.Thirsty:
                CurrentTargetIndex = 2;
                MoveToNextTarget();
                break;
            default:
                Debug.LogError("Invalid animal needs provided.");
                break;
        }
    }
}

public enum AnimalNeeds
{
    Hungry,
    Sleepy,
    Thirsty
}