using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Transform weaponPos;
    public GameObject bullet;
    private float force= 10.0f;
    private bool imIDead;
    public Transform initalPos;

    // Start is called before the first frame update
    void Start()
    {
        imIDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.M))
        {
            var bullets = Instantiate(bullet, weaponPos.position, Quaternion.identity);

            var rb= bullets.GetComponent<Rigidbody>();

            rb.AddForce(weaponPos.transform.forward *force, ForceMode.Impulse);
        }
    }

    public bool status()
    {
        return imIDead;
    }

    public void setDeath()
    {
        imIDead = true;
    }    
    public void reivive()
    {
        transform.position = initalPos.position;
        transform.rotation = initalPos.rotation;
        imIDead = false;
    }
}
