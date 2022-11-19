using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter ( Collider col )
    {
        if ( col. gameObject. tag=="ulti" )
        {
            Destroy ( this. gameObject );
            Debug. Log ( 12312 );
        }

      // Destroy ( this. gameObject, 4f );
    }
}
