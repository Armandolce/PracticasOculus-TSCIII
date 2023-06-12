using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private bool isOnPlat;
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            isOnPlat = true;
        }
    }    
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            isOnPlat = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isOnPlat = false;
    }

    public bool ConfirmWin()
    {
        return isOnPlat;
    }

}
