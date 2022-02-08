using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //Takes this as the weapons to manipulate
    public GameObject Weapon;
    public GameObject myWeapon;
    //Where the Weapon should be instantiated
    public Transform Location;
    //Checks if the player has the Stick of Truth or not
    private bool hasWeapon = false;
    //Animator for the weapons object
    private Animator myAni;

    //will tell the computer weapon was picked up and can detroy the original
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasWeapon = true;
            Destroy(Weapon);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            Instantiate(myWeapon, Location.position, Location.rotation);
            myAni.SetBool("Attacking", true);
            Destroy(myWeapon,10f);
            myAni.SetBool("Attacking", false);
        }
    }
}
