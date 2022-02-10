using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //Takes this as the weapons to manipulate
    public GameObject Weapon;
    public GameObject myWeapon;
    public GameObject Sweapon;
    //Where the Weapon should be instantiated
    public Transform Location;
    //Checks if the player has the Stick of Truth or not
    private bool hasWeapon = false;
    //number for counter
    float counter;

    //will tell the computer weapon was picked up and can detroy the original
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            hasWeapon = true;
            Destroy(Weapon);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //counts down in real time as a cool down for the attack
        counter -= Time.deltaTime;
        if (hasWeapon == true && counter <= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                myWeapon = Instantiate(Sweapon, Location.position, Location.rotation);
                Destroy(myWeapon,0.4f);
                counter = 1;
            }
        }
    }
}
