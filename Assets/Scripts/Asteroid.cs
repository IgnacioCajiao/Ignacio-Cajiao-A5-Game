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

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        transform.localScale = Vector3.one * size;
        rb.mass = size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(gameObject, lifeTime);

    }
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

    private void CreateClone()
    {
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid clone = Instantiate(this, position, transform.rotation);
        clone.size = size / 2;
        clone.SetTrajectory(Random.insideUnitCircle.normalized * speed);
    }
}
