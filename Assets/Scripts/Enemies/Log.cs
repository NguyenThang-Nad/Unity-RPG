using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy

{
    public Rigidbody2D myRigidbody2D;
    [Header("Target Variables")]
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    //public Transform homePosition;
    // Start is called before the first frame update
    void Start()

    {
        currentState = EnemyState.idle;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("wakeUp", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }
    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position,
                            transform.position) <= chaseRadius
           && Vector3.Distance(target.position,
                               transform.position) > attackRadius
                               
                               )
        {
            if (currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                         target.position,
                                                         moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myRigidbody2D.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else
        {
            anim.SetBool("wakeUp", false);
        }

    }
     public void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("MoveX", setVector.x);
        anim.SetFloat("MoveY", setVector.y);
    }
    public void ChangeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    public void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
