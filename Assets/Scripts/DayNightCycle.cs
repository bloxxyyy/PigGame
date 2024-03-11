using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private float dayLengthInSeconds = 120f;

    [SerializeField]
    private Transform sunTransform;

    [SerializeField]
    private GameObject[] lampObjects;

    [SerializeField]
    private float duskThreshold = 0.7f;

    [SerializeField]
    private float dawnThreshold = 0.3f;

    private float timeOfDay = 0f;

    void Update()
    {
        UpdateTimeOfDay();
        UpdateSunRotation();
        UpdateLamps();
    }

    void UpdateTimeOfDay()
    {
        timeOfDay += Time.deltaTime / dayLengthInSeconds;
        if (timeOfDay > 1f)
        {
            timeOfDay -= 1f;
        }
    }

    void UpdateSunRotation()
    {
        float angle = timeOfDay * 360f;
        sunTransform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
    }

    void UpdateLamps()
    {
        if (timeOfDay > duskThreshold || timeOfDay < dawnThreshold)
        {
            SetLamps(true);
        } else
        {
            SetLamps(false);
        }
    }

    void SetLamps(bool isEnabled)
    {
        foreach (GameObject lamp in lampObjects) lamp.SetActive(isEnabled);
    }
}
