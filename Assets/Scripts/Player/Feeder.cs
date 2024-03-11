using Unity.VisualScripting;
using UnityEngine;

public class Feeder : MonoBehaviour
{
    [SerializeField]
    private float feedingTime = 3f;

    [SerializeField]
    private Material newMaterial;

    [SerializeField]
    private GameObject model;

    [SerializeField]
    private Material oldMaterial;

    private void OnEnable()
    {
        model.GetComponent<Renderer>().material = newMaterial;
        StartCoroutine(RevertMaterialAfterDelay());
    }

    private System.Collections.IEnumerator RevertMaterialAfterDelay()
    {
        yield return new WaitForSeconds(feedingTime);
        model.GetComponent<Renderer>().material = oldMaterial;
        Variables.ActiveScene.Set("IsFeeding", false);
    }
}
