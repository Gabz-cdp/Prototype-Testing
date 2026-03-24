using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6; //tracks the speed of the character
    public int facingDirection = 1;  //Tracks the direction the character is facing (the set value is 1 to face RIGHT)
    public Rigidbody2D rb; //Handles all the physics
    public Animator anim; //Reference to the animator


    // FixedUpdate is called 50 times per frame and more reliable for physics calculations
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); //Stores the input along the horizontal axis (tracks character movement horizontally)
        float vertical = Input.GetAxis("Vertical");  //Checking vertical axis and tracking movement

        if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        //checks to see that the character is facing right and if he flips then it changes the facing direction
        {
            Flip();
        }

                                                            //To animate moving left horizontal = +1
        anim.SetFloat("horizontal", Mathf.Abs(horizontal)); //comparing the horizontal from the script to the horizontal of the animation
        anim.SetFloat("vertical", Mathf.Abs(vertical));     //comparing the vertical from the script to the vertical of the animation

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed; //Ridgidbody's velocity is equal to the horizonal and vertical inputs
                                                                       //Multiply by speed so that the character isn't moving at 1 but at the speed set
    }


    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); 
        //Giving the new "x" value by relating it to the actual reading in the transform panel but "y" and "z" dont change
    }
}
