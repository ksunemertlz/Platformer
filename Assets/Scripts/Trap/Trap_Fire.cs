using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Fire : Trap
{
    private Animator anim;
    private bool isWorking;
    private float cooldown = 2;
    private float cooldownTimer;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(isWorking)
          base.OnTriggerEnter2D(collision);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if(cooldownTimer < 0 )
        {
            isWorking = !isWorking;
            cooldownTimer = cooldown;
        }
        anim.SetBool("isWorking", isWorking);
    }
}
