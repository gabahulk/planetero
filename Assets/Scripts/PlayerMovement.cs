using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Planet planet;
    [Range(0,10)]
    public float speed;
    public Rigidbody rb;
    public float jumpHeight = 1.2f;

    bool isGrounded = false;
    float distanceToGround;
    Vector3 groundNormal;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * 4000 * jumpHeight * Time.deltaTime);
        }



        // ground controll

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            groundNormal = hit.normal;
            isGrounded = distanceToGround <= 0.1f;
        }


        ///   Gravity and rotation
        ///   

        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;

        if (!isGrounded)
        {
            rb.AddForce(gravDirection * -planet.gravity);
        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }
}
