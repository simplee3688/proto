using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdoptChild : MonoBehaviour
{
    SpriteRenderer rend;
    FixedJoint2D fx;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        fx = GetComponent<FixedJoint2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rend.color = Color.yellow;
            if (Input.GetKey(KeyCode.X))
            {
                transform.parent = collision.transform;
                transform.tag = "PlayerAttachment";
                fx.enabled = true;
                fx.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            }
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rend.color = Color.black;
        }
    }
}
