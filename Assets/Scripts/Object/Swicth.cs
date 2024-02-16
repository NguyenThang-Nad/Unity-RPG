using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swicth : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;
    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.RuntimeValue;
        // mySprite = GetComponent<SpriteRenderer>();
        if (active)
        {
            ActiveSwitch();
        }
    }
    public void ActiveSwitch()
    {
        active = true;
        storedValue.RuntimeValue = active;
        thisDoor.Open();
        mySprite.sprite = activeSprite;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveSwitch();
        }
    }
}
