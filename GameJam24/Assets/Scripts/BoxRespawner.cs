using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject respawnMarker1;
    public GameObject prefab2;
    public GameObject respawnMarker2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(prefab1, respawnMarker1.transform.position, Quaternion.identity);
            Instantiate(prefab2, respawnMarker2.transform.position, Quaternion.identity);
        }
    }
}
