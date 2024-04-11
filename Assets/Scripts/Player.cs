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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        thrust = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.LeftArrow))
            turnDirection = 1.0f;
        else if (Input.GetKey(KeyCode.RightArrow))
            turnDirection = -1.0f;
        else turnDirection = 0.0f;

    }
    public void FixedUpdate()
    {
        if (thrust)
            rb.AddForce(this.transform.up * this.thrustSpeed);

        if (turnDirection != 0.0f)
        {
            rb.AddTorque(turnDirection * this.turnSpeed);
        }
            
    }
}
