using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}
public class Door : Interactable
{
    [Header("Door Variable")]
    public DoorType thisDoorType;
    public bool open =false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public  BoxCollider2D physicsCollider;
    // Start is called before the first frame update
    //private void Start()
    //{
    //    doorSprite = GetComponent<SpriteRenderer>();
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if(playerInRange && thisDoorType==DoorType.key)
            {
                //Does the player have a key?
                if(playerInventory.numberOfKey > 0)
                {
                    playerInventory.numberOfKey--;
                    //If so door open
                    Open();
                }


            }
        }
    }
    public  void Open()
    {
        //Turn off sprite renderer
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;

    }

    // Update is called once per frame
    public void Close()
    {
        
    }
}
