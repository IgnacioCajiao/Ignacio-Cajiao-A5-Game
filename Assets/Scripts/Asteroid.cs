using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{   
    public float size = 1.0f;
    private Rigidbody2D rb;
    public float maxSize = 1.5f;
    public float minSize = 0.5f;
    public float speed = 50.0f;
    public float lifeTime = 30.0f;
    public static int score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // this sets a random rotation, also sets size and mass of the asteroids
    void Start()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        transform.localScale = Vector3.one * size;
        rb.mass = size;
    }
    // applies force and direction to the asteroid, also destroys them after 30sec
    public void SetTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(gameObject, lifeTime);

    }
    // if the asteroid collides with the projectile if the size of the asteroid /2 is greater then the min size call 2 clone functions.
    // also destroys the first asteroid. also calls asteroid destroyed to increase score on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile") 
        {
            AsteroidDestroyed(this);
            if ((size / 2) >= minSize)
            {
                CreateClone();
                CreateClone();
            }
            Destroy(gameObject);           
        }
    }
    // increases score depending on the size of asteroid you destroyed.
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        if (asteroid.size < 0.65f)
        {
            score += 100;
        }
        else if (asteroid.size > 0.8f)
        {
            score += 50;
        }
    }
    // this creates the two clones around the original asteroid, makes them half the size of the original and gives them a trajectory and speed.
    private void CreateClone()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid clone = Instantiate(this, position, transform.rotation);
        clone.size = size / 2;
        clone.SetTrajectory(Random.insideUnitCircle.normalized * speed);
    }
}
