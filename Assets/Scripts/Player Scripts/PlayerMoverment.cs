using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMoverment : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;
    public Animator animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
   // public Signal playerHit;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }   

    // Update is called once per frame
    void Update()
    {
        //Is player in an interract
        if(currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal") ;
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        if(currentState== PlayerState.walk || currentState == PlayerState.idle)
        UpdateAnimationMove();
    }
    public void RaiseItem()
    {
        if(playerInventory.currentItem != null) { 
        if (currentState != PlayerState.interact)
        {
            animator.SetBool("Receive", true);
            currentState = PlayerState.interact;
            receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
        }
        else
        {
            animator.SetBool("Receive", false);
            currentState = PlayerState.idle;
            receivedItemSprite.sprite = null;
            playerInventory.currentItem = null;
        }
        }
    }
   private IEnumerator AttackCo()
    {
        animator.SetBool("attacking",true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
    void UpdateAnimationMove()
    {
        if (change != Vector3.zero)
        {
            Moving();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void Moving()
    {
        change.Normalize();
        rb.MovePosition(
            transform.position + change * speed*Time.deltaTime);
    }
    public void Knock(float knockTime,float damage)
    {
        currentHealth.initiaValue -= damage;
       // playerHealthSignal.Raise();
        if (currentHealth.initiaValue > 0)
        {
           // playerHit.Raise();
            playerHealthSignal.Raise();
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private IEnumerator KnockCo(float knockTime)
    {
        if (rb != null)
        {
            //StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rb.velocity = Vector2.zero;
        }
    }
}
