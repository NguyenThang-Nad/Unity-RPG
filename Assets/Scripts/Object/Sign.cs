using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;


    // Start is called before the first frame update
    void Start()
    {
       // dialogBox.SetActive(false); // Make sure the dialog box is not visible at start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange) // Changed GetKey to GetKeyDown
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private  void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false); // Hide the dialog box when the player leaves
        }
    }
}
