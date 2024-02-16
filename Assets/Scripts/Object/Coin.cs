using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            playerInventory.coins += 1;
            Destroy(this.gameObject);
            powerUpSignal.Raise();
        }
    }
}
