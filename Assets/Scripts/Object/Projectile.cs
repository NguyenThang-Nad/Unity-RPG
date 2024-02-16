using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame
    [Header("Movement Stuff")]
    public int moveSpeed;
    public Vector2 directionMove;
    public float lifetime;
    private float lifetimeSeconds;
    private Rigidbody2D myRigidbody2D;
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        lifetimeSeconds = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if(lifetimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Lauch(Vector2 initial)
    {
        myRigidbody2D.velocity = initial * moveSpeed;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
