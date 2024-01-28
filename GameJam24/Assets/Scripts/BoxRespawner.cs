using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject respawnMarker1;
    public GameObject prefab2;
    public GameObject respawnMarker2;
    public GameObject prefab3;
    public GameObject respawnMarker3;
    public GameObject prefab4;
    public GameObject respawnMarker4;
    public GameObject prefab5;
    public GameObject respawnMarker5;
    public GameObject prefab6;
    public GameObject respawnMarker6;
    public GameObject prefab7;
    public GameObject respawnMarker7;
    public GameObject prefab8;
    public GameObject respawnMarker8;
    public GameObject prefab9;
    public GameObject respawnMarker9;
    public GameObject prefab10;
    public GameObject respawnMarker10;
    public GameObject prefab11;
    public GameObject respawnMarker11;
    public GameObject prefab12;
    public GameObject respawnMarker12;
    public GameObject prefab13;
    public GameObject respawnMarker13;
    public GameObject prefab14;
    public GameObject respawnMarker14;
    public GameObject prefab15;
    public GameObject respawnMarker15;
    public GameObject prefab16;
    public GameObject respawnMarker16;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(prefab1, respawnMarker1.transform.position, Quaternion.identity);
            Instantiate(prefab2, respawnMarker2.transform.position, Quaternion.identity);
            Instantiate(prefab3, respawnMarker3.transform.position, Quaternion.identity);
            Instantiate(prefab4, respawnMarker4.transform.position, Quaternion.identity);
            Instantiate(prefab5, respawnMarker5.transform.position, Quaternion.identity);
            Instantiate(prefab6, respawnMarker6.transform.position, Quaternion.identity);
            Instantiate(prefab7, respawnMarker7.transform.position, Quaternion.identity);
            Instantiate(prefab8, respawnMarker8.transform.position, Quaternion.identity);
            Instantiate(prefab9, respawnMarker9.transform.position, Quaternion.identity);
            Instantiate(prefab10, respawnMarker10.transform.position, Quaternion.identity);
            Instantiate(prefab11, respawnMarker11.transform.position, Quaternion.identity);
            Instantiate(prefab12, respawnMarker12.transform.position, Quaternion.identity);
            Instantiate(prefab13, respawnMarker13.transform.position, Quaternion.identity);
            Instantiate(prefab14, respawnMarker14.transform.position, Quaternion.identity);
            Instantiate(prefab15, respawnMarker15.transform.position, Quaternion.identity);
            Instantiate(prefab16, respawnMarker16.transform.position, Quaternion.identity);
        }
    }
}
