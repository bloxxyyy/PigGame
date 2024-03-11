using Unity.VisualScripting;
using UnityEngine;

public class StartFarming : MonoBehaviour
{
    [SerializeField]
    private string targetTag;

    [SerializeField]
    private string newTag;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag(targetTag))
        {
            hit.collider.gameObject.tag = newTag;
            Variables.ActiveScene.Set("IsFeeding", true);
            hit.collider.gameObject.GetComponent<IsGrowing>().enabled = true;
        }
    }
}
