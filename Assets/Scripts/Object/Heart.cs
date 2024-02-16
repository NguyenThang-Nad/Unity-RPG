using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    // Start is called before the first frame update

    public FloatValue playerHealth;
    public float amountToIncreate;
    public FloatValue heartContainer;
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

            playerHealth.initiaValue += amountToIncreate;
            if (playerHealth.initiaValue > heartContainer.initiaValue * 2f)
            {
                playerHealth.initiaValue = heartContainer.initiaValue * 2f;
            }
            Destroy(this.gameObject);
            powerUpSignal.Raise();
        }
    }
}
