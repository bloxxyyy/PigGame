using System;
using System.Collections;
using UnityEngine;

public class TryInteract : MonoBehaviour
{
    [SerializeField]
    private float detectionRange = 1.5f;

    [SerializeField]
    private string plantTag = "Plant";

    [SerializeField]
    private Transform sleepPlace;

    [SerializeField]
    private Transform drinkPlace;

    [SerializeField]
    private AnimalNeedsManager anm;

    [SerializeField]
    private MoveAnimal moveAnimal;

    [SerializeField]
    private Material newMaterial;

    [SerializeField]
    private Material oldMaterial;

    public bool isBusy = false;


    private void Update()
    {
        if (isBusy) return;
        if (moveAnimal.CurrentTargetIndex == 1 && Vector3.Distance(transform.position, sleepPlace.position) < detectionRange)
        {
            anm.sleepiness = 50f;
            isBusy = true;
            GetComponent<Renderer>().material = newMaterial;
            StartCoroutine(WaitAndChangeMaterial(5f));
        }

        if (moveAnimal.CurrentTargetIndex == 2 && Vector3.Distance(transform.position, drinkPlace.position) < detectionRange)
        {
            anm.thirst = 50f;
            isBusy = true;
            GetComponent<Renderer>().material = newMaterial;
            StartCoroutine(WaitAndChangeMaterial(5f));
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag(plantTag))
            {
                OnRemove onRemoveComponent = col.GetComponent<OnRemove>();
                if (onRemoveComponent != null)
                {
                    anm.hunger = 50f;
                    onRemoveComponent.onRemoveAction?.Invoke();
                }
            }
        }
    }

    private IEnumerator WaitAndChangeMaterial(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Renderer>().material = oldMaterial;
        isBusy = false;
        moveAnimal.CurrentTargetIndex = -1;
    }
}
