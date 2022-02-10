using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    //holds the game object block that needs to be instantiated
    public GameObject Block;
    public GameObject myBlock;
    //where the block should be spawned
    public Transform Spawner;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (myBlock != null)
            {
                Destroy(myBlock);
            }
            myBlock = Instantiate(Block, Spawner.position, Spawner.rotation);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
