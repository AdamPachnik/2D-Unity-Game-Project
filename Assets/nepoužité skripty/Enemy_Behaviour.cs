using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region public Variables
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    [HideInInspector]public Transform Target;
    [HideInInspector]public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public Transform LeftLimit;
    public Transform RightLimit;
    #endregion
    #region private Variables
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool coolin;
    private float intTimer;
    #endregion
     void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    void cooldown()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && coolin && attackMode)
        { 
            coolin = false;
            timer = intTimer;
        }
    }
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            SelectTarget();
        }
        if (inRange)
        {
            EnemyLogic();
        }
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, Target.position);
        if (distance> attackDistance)
        {
            
            StopAttack();
        }
        else if (attackDistance >= distance && coolin == false)
        {
            Attack();
        }
        if (coolin)
        {
            cooldown(); 
            anim.SetBool("Attack", false);
        }
    }
    void Move()
    {
        anim.SetBool("canWalk", true)  ;
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(Target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }
    void StopAttack()
    {
        coolin = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
 
  public void TriggerCooling()
    {
        coolin = true;
    }
     
    private bool InsideofLimits()
    {
        return transform.position.x > LeftLimit.position.x && transform.position.x < RightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, LeftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, RightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            Target = LeftLimit;
        }
        else
        {
            Target = RightLimit;
        }
        Flip();
    }
    public  void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > Target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
}
