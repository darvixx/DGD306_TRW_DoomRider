using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public float detectionRange = 5f;

    Transform player2;
    Rigidbody2D rb;
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player2");
        if (playerObj != null)
        {
            player2 = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Boss_Walk: 'Player2' tag'li obje bulunamad�!");
        }

        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player2 == null) return;

        if (Vector2.Distance(player2.position, rb.position) <= detectionRange)
        {
            boss.LookAtPlayer();

            Vector2 target = new Vector2(player2.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            if (Vector2.Distance(player2.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
