using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 500.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // adds force to projectile 
    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
    // when projectile collides with anything it is destroyed
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Destroy(gameObject);
    }
}
