using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Planet planet;

    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateOrbitMovement(){
        float dist = Vector3.Distance(planet.transform.position, transform.position);
        if (dist < 1) dist = 1;

        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;
        Vector3 gravPull = gravDirection * (-planet.gravity/dist);

        GetComponent<Rigidbody>().AddForce(gravPull);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded){
            UpdateOrbitMovement();
        }else{
            //  UpdateGroundedMovement();
        }
        
    }
}
