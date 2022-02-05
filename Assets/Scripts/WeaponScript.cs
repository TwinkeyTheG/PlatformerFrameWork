using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //Takes this as the weapons object in question
    public GameObject Weapon;
    //Where the Weapon should be instantiated
    public Transform Player;
    //Checks if the player has the Stick of Truth or not
    private bool hasWeapon = false;
    //Animator for the weapons object
    private Animation myAni;



    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("E"))
        {
            Instantiate(Weapon, transform.position, transform.rotation);
            myAni.Play("AttackingAnimation");
        }
    }

    //will tell the computer weapon was picked up and can detroy the original
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            hasWeapon = true;
            Destroy(Weapon);
        }
    }
}
