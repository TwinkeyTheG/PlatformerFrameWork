using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public float speed;
    public bool movingRight = false;

    public Transform frontDetection;
    public Transform backDetection;

    private Rigidbody2D myRB;

    private Animator myAni;

    public float groundRayDist = 2f;
    public float wallRayDist = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir;
    
        if (movingRight)
        {
            moveDir = Vector2.right;

        }
        else
        {
            moveDir = -Vector2.right;
        }

        myRB.AddForce(moveDir * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(frontDetection.position, Vector2.down, groundRayDist);
        RaycastHit2D backGroundInfo = Physics2D.Raycast(backDetection.position, Vector2.down, groundRayDist);
        RaycastHit2D wallInfo = Physics2D.Raycast(frontDetection.position, moveDir, wallRayDist);
        RaycastHit2D backWallInfo = Physics2D.Raycast(backDetection.position, -moveDir, wallRayDist);
        //make sure that it can keep going a direction or switch, or just stop turning if trapped on both sides
        //if there wasn't a back check it would spaz if pushed into a strange place
        if ((groundInfo.collider == false || wallInfo.collider != false) && (backGroundInfo.collider == true && backWallInfo.collider != true))
        {
            movingRight = !movingRight;
            transform.eulerAngles += new Vector3(0, 180, 0);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            myAni.Play("Death");
            Destroy(Enemy,0.6f);
        }
    }
}
