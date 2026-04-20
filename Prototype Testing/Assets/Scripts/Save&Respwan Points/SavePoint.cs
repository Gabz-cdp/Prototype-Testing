using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private RespawnPoint RespawnPoint;
    public GameObject Bed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RespawnPoint = GameObject.Find("Willow FV").GetComponent<RespawnPoint>();  
    }

    //trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Willow FV")
        {
            RespawnPoint.respawnPoint = transform.position;
            Bed.SetActive(true);
        }
    }
}
