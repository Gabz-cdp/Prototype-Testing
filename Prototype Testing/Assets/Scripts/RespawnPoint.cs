using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Vector3 respawnPoint;
    
    public void RespawnNow() //Calls the method everytime the player respawns
    {
        transform.position = respawnPoint; //Since the script is on the player, it will automatically find the player's position
    }

    //Add trigger for reason of respawn
    private void OnCollisionEnter2D(Collision2D collision) //A method that is called whenever this object enters another collider
    {
        if (collision.gameObject.tag == "Save")
        {
            RespawnNow();
        }
    }
}
