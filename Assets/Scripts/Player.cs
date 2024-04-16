using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool thrust;
    private float turnDirection;
    private Rigidbody2D rb;
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public Projectile projectilePrefab;
    public GameOverTextController gameOverTextController;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // set up for player controls also calls shoot funciton on space press.
    void Update()
    {
        thrust = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.LeftArrow))
            turnDirection = 1.0f;
        else if (Input.GetKey(KeyCode.RightArrow))
            turnDirection = -1.0f;
        else turnDirection = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

    }
    // apply forces to rigidbody for thrust and rotation.
    public void FixedUpdate()
    {
        if (thrust)
            rb.AddForce(transform.up * thrustSpeed);

        if (turnDirection != 0.0f)
        {
            rb.AddTorque(turnDirection * turnSpeed);
        }
            
    }
    // Creates a projectile at the players location and rotation, then calls project to make it move.
    private void Shoot()
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.Project(transform.up);
    }
    // checks if player collided with asteriod, if so player is destroyed and game over text is displayed.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
            gameOverTextController.ShowGameOverText();
        }
    }
}
