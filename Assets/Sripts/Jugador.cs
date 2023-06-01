using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Transform weaponPos;
    public GameObject bullet;
    private float force= 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
