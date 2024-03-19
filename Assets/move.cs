using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private float force, forceA , mass, acceleration;
    private bool canJump = true;
    //public float jumpCooldown = 1f;

// Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * force);
            
        }
    }

    public Rigidbody rb;

    void FixedUpdate()
    {
       
        
    }

    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)&& canJump)
        {
            forceA = mass * acceleration;
            mass = GetComponent<Rigidbody>().mass;
            GetComponent<Rigidbody>().AddForce(0,forceA,forceA);
            canJump = false;
            //StartCoroutine(JumpCooldown());
        }
    }
    /*private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
}
