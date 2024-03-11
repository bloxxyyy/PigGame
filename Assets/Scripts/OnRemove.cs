using System;
using UnityEngine;

public class OnRemove : MonoBehaviour
{
    public Action onRemoveAction { get; private set; }

    public void Start()
    {
        onRemoveAction += Remove;
    }

    public void Remove() {
        GameObject parentObject = transform.parent.gameObject;
        parentObject.tag = "NotGrowing";
        Destroy(gameObject);
    }
}
