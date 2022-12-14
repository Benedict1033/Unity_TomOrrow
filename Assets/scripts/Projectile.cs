using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    public float speed = 10;
   int damage = 1;

    float lifetime = 2.5f;
    float skinWidth = .1f;

    void Start()
    {
        Destroy(gameObject, lifetime);

        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if(initialCollisions.Length>0)
        {
            OnHitObject(initialCollisions[0],transform.position);
        }
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    void Update()
    {
        float moveDistance = (speed * Time.deltaTime)/30;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,moveDistance+skinWidth,collisionMask,QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit.collider,hit.point);
        }
    }


    void OnHitObject(Collider c,Vector3 hitPoint)
    {
        Idamageble damagebleObject = c.GetComponent<Idamageble>();
        if(damagebleObject!=null)
        {
            damagebleObject.TakeHit(damage,hitPoint,transform.forward);
        }
        GameObject.Destroy(gameObject);
    }

}
