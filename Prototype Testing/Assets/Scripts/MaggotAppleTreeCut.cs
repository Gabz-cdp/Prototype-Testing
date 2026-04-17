using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaggotAppleTreeCut : Tool
{
    [SerializeField] GameObject Drop;
    [SerializeField] int DropCount = 1; //How many objects to drop from the Maggot Apple Tree
    [SerializeField] float spread = 2f; //How spread out the dropped Maggot Apples are

    public override void Hit()
    {
        while(DropCount > 0)
        {
            DropCount -= 1; 
            Vector3 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.y += spread * UnityEngine.Random.value - spread / 2; //Gets random values in a certain area for the Maggot Apples to drop
            GameObject go = Instantiate(Drop);
            go.transform.position = pos;
        }

        Destroy(gameObject);
    }
}
