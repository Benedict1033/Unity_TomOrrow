﻿using System. Collections;
using System. Collections. Generic;
using UnityEngine;

[RequireComponent ( typeof ( UnityEngine. AI. NavMeshAgent ) )]
public class star : moster_entity
{
    public enum State { Idle, Chasing, Attacking };
    State currentState;

    public ParticleSystem deathEffect;

    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;
    PlayerLiving targetEntity;
    Material skinMaterial;

    float attackDistanceThreshold = 120f;
    float timeBetweenAttacks = 1;
    int damage = 1;

    Color originalColor;

    float nextAttackTime;
    float myCollisionRadius;
    float targetCollisionRadius;

    bool hasTarget;

    public GameObject panel;
    public GameObject Star;

  


    protected override void Start ( )
    {
        base. Start ( );
        pathfinder=GetComponent<UnityEngine. AI. NavMeshAgent> ( );
        skinMaterial=GetComponent<Renderer> ( ). material;
        originalColor=skinMaterial. color;

        if ( GameObject. FindGameObjectsWithTag ( "Player" )!=null )
        {
            currentState=State. Chasing;
            hasTarget=true;
            target=GameObject. FindGameObjectWithTag ( "Player" ). transform;

            targetEntity=target. GetComponent<PlayerLiving> ( );
            targetEntity. OnDeath+=OnTargetDeath;

            myCollisionRadius=GetComponent<CapsuleCollider> ( ). radius;
            targetCollisionRadius=target. GetComponent<CapsuleCollider> ( ). radius;

            StartCoroutine ( UpdatePath ( ) );
        }
    }

    public override void TakeHit ( int damage, Vector3 hitPoint, Vector3 hitDirection )
    {
        if ( damage>=health )
        {
            Destroy ( Instantiate ( deathEffect. gameObject, hitPoint, Quaternion. FromToRotation ( Vector3. forward, hitDirection ) ) as GameObject, deathEffect. startLifetime );
        }
        base. TakeHit ( damage, hitPoint, hitDirection );
    }

    void OnTargetDeath ( )
    {
        hasTarget=false;
        currentState=State. Idle;

    }

    void Update ( )
    {
        if ( hasTarget )
        {
            if ( Time. time>nextAttackTime )
            {
                float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
                //  Debug.Log(sqrDstToTarget);
                if ( sqrDstToTarget<Mathf. Pow ( attackDistanceThreshold+myCollisionRadius+targetCollisionRadius, 2 ) )
                {
                    nextAttackTime=Time. time+timeBetweenAttacks;
                    StartCoroutine ( Attack ( ) );
                }
            }
        }

        if ( moster_entity. health<=1 )
        {
              StartCoroutine ( WAIT ( ) );
     

        }

  
    }

    IEnumerator Attack ( )
    {
        currentState=State. Attacking;
        pathfinder. enabled=false;

        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (target.position-transform.position).normalized;
        Vector3 attackPosition = target.position - dirToTarget * (myCollisionRadius);

        float attackSpeed = 3;
        float percent = 0;

        skinMaterial. color=Color. red;
        bool hasAppliedDamage = false;

        while ( percent<=1 )
        {
            if ( percent>=.5f&&!hasAppliedDamage )
            {
                hasAppliedDamage=true;
                targetEntity. TakeDamage ( damage );
            }

            percent+=Time. deltaTime*attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform. position=Vector3. Lerp ( originalPosition, attackPosition, interpolation );

            yield return null;
        }
        skinMaterial. color=originalColor;
        currentState=State. Chasing;
        pathfinder. enabled=true;
    }


    IEnumerator UpdatePath ( )
    {
        float refreshRate = .25f;

        while ( hasTarget )
        {
            if ( currentState==State. Chasing )
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
                if ( !dead )
                {
                    pathfinder. SetDestination ( targetPosition );
                    yield return new WaitForSeconds ( refreshRate );
                }
            }
            yield return new WaitForSeconds ( refreshRate );
        }
    }


    IEnumerator WAIT ( )
    {
        yield return new WaitForSeconds ( 0.9f );

        
        panel. SetActive ( true );
        Star. SetActive ( true );

  

    }
}
