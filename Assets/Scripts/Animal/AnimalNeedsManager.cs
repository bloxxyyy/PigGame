using UnityEngine;

public class AnimalNeedsManager : MonoBehaviour
{
    [SerializeField]
    private MoveAnimal moveAnimal;
    [SerializeField]
    private TryInteract tryInteract;
            
    public float hunger = 50;
    public float thirst = 50;
    public float sleepiness = 50;

    [SerializeField]
    private float needThreshold = 35f;

    [SerializeField]
    private float destroyThreshold = 0f;

    private void Update()
    {
        UpdateNeedsOverTime();
        DetermineNeeds();
    }

    private void UpdateNeedsOverTime()
    {
        hunger -= Time.deltaTime;
        thirst -= Time.deltaTime;
        sleepiness -= Time.deltaTime;
    }

    private void DetermineNeeds()
    {
        if (!tryInteract.isBusy)
        {
            if (hunger <= needThreshold || thirst <= needThreshold || sleepiness <= needThreshold)
            {
                if (hunger <= thirst && hunger <= sleepiness)
                {
                    moveAnimal.SetDestinationBasedOnNeeds(AnimalNeeds.Hungry);
                } else if (thirst <= hunger && thirst <= sleepiness)
                {
                    moveAnimal.SetDestinationBasedOnNeeds(AnimalNeeds.Thirsty);
                } else
                {
                    moveAnimal.SetDestinationBasedOnNeeds(AnimalNeeds.Sleepy);
                }
            }
        }

        if (hunger <= destroyThreshold || thirst <= destroyThreshold || sleepiness <= destroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
