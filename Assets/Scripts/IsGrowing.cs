using UnityEngine;

public class IsGrowing : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn;

    private void OnEnable()
    {
        StartCoroutine(SpawnAfterDelay(5f));
    }

    private System.Collections.IEnumerator SpawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(objectToSpawn, transform.position, Quaternion.identity, transform);
        enabled = false;
    }
}
