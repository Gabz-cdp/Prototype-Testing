using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float Speed = 100f; //Speed of the Maggot Apple to collect (smaller than player speed)
    [SerializeField] float PickUpDistance = 50f;
    [SerializeField] float DespawnTime = 10f; //Spawn rate of 10 seconds

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        DespawnTime -= Time.deltaTime; //Despwans after the time limit of 10 seconds
        if (DespawnTime < 0)
        {
            Destroy(gameObject);
        }
        float distance = Vector3.Distance(transform.position, player.position); //Maggot Apple moves toward Willow
        if (distance > PickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
