using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitOnDeadPig : MonoBehaviour
{
    [SerializeField]
    private GameObject objToCheck;

    void Update()
    {
        if (objToCheck == null)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
