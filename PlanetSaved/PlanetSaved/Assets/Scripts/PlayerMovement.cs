using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRidudbody2D;
    [SerializeField] private float movementSpeed;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRidudbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Flip(horizontal);
    }

    private void HandleMovement(float horizontal)
    {
        myRidudbody2D.velocity = new Vector2(horizontal * movementSpeed, myRidudbody2D.velocity.y);
    }
    
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
