
using UnityEngine;

public interface Idamageble
{
    void TakeHit(int damage, Vector3 hitPoint,Vector3 hitDirection);

    void TakeDamage(int damage);

}