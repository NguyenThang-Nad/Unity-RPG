using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange) // Changed GetKey to GetKeyDown
        {
            if (!isOpen) {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpen();
            }
        }
    }
    public void OpenChest()
    {
        //DialogWindowOn
        dialogBox.SetActive(true);
        //Dialog text-contenets text
        dialogText.text = contents.itemDescription;
        //add contents  to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //Raise the signal to the player to animate
        raiseItem.Raise();

        //raise the context clue
        context.Raise();
        //set the chest to open
        isOpen = true;
        anim.SetBool("opened", true);

    }
    public void ChestAlreadyOpen()
    {

            //Dialog Off
            dialogBox.SetActive(false);
            //Current Item == null
            //playerInventory.currentItem = null;
            raiseItem.Raise();

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;

        }
    }
}
