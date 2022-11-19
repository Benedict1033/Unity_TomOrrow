using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine. UI;

public class xpbar : MonoBehaviour
{
   public static Image XP;
  
    public GameObject player;

    public static float XP_Amount;
    void Start ( )
    {
        XP=GetComponent<Image> ( );
        XP_Amount=0f;
    }

    void Update ( )
    {
        XP. fillAmount=XP_Amount;

        }
}
