using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentChecker : MonoBehaviour
{
    public static List<string> destroyedBefore = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        if (destroyedBefore.Contains(gameObject.name))
        {
            Destroy(gameObject);
        }
    }

    public void destroyPresent()
    {
        if (!destroyedBefore.Contains(gameObject.name))
        {
            destroyedBefore.Add(gameObject.name);
        }
    }
}
