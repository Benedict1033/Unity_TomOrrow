using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ative : MonoBehaviour
{

    public GameObject Active;


    void Start()
    {
        StartCoroutine ( active ( ) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator active ( )
    {
        yield return new WaitForSeconds ( 5 );

        Active. SetActive ( true );

    }
}
