using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class UI : MonoBehaviour
{

  

    public void next ( )
    {
        SceneManager. LoadScene ( "Game" );
    }

    public void Exit ( )
    {
        Application. Quit ( );
    }

    public void StartNewGame ( )
    {
        SceneManager. LoadScene ( "Game" );
    }

    public void Menu ( )
    {
        SceneManager. LoadScene ( "start" );
    }

    private void Update ( )
    {
       
    }
}
