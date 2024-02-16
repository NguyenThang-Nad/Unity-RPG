using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrush;
    public float knockTime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Nhấn crt K + ctrl U để comment.Còn Uncomment thì crtl U + crtl C
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Pot>().Smash();
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        { 
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrush;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy"))
                {
                    Enemy enemy = other.GetComponent<Enemy>();
                    if (enemy != null && enemy.isAlive) // Kiểm tra isAlive từ đối tượng Enemy
                    {
                        enemy.currentState = EnemyState.stagger;
                        enemy.Knock(hit, knockTime, damage);
                    }
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerMoverment>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMoverment>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMoverment>().Knock(knockTime,damage);
                    }
                }
            }
        }
    }

}
