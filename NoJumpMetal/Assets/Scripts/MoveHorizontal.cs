using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    public float speed;
    public float fric;
    public float maxspeed;
    public float min;
    

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Transform[] tp = GetComponentsInChildren<Transform>();
            foreach (Transform child in tp)
            {
                Debug.Log(child.name);
                if (child.tag == "PlayerAttachment")
                {
                    

                    child.tag = "MapObject";
                    child.transform.parent = null;
                    child.GetComponent<FixedJoint2D>().enabled = false;

                    

                }

            }
        }


    }

    void FixedUpdate()
    {
        //Debug.Log(rb.worldCenterOfMass);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity += speed;
            //rb.AddForce(new Vector2(-min, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity -= speed;
            //rb.AddForce(new Vector2(min, 0));
        }
        else if (rb.velocity.y == 0)
        {
            rb.angularVelocity = rb.angularVelocity * fric;
        }
        if (Mathf.Abs(rb.angularVelocity) > maxspeed)
        {
            if (rb.angularVelocity > 0)
            {
                rb.angularVelocity = maxspeed;
            }
            else
            {
                rb.angularVelocity = -maxspeed;
            }


        }

        
    }
}
