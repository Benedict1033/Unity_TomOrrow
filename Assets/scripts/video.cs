using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class video : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine ( Video ( ) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Video ( )
    {
       
            yield return new WaitForSeconds (4f);

        this. gameObject. SetActive ( false );
       



    }
}
