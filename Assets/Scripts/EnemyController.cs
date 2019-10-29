using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Planet planet;

    GameObject playerReference;

    bool isGrounded = false;
    float distanceToGround = 100;

    Vector3 groundNormal = Vector3.zero;

    // Start is called before the first frame update

    public void SetPlayerReference(GameObject playerReference){
        this.playerReference = playerReference;
    }

    void UpdateOrbitMovement(){
        float dist = Vector3.Distance(planet.transform.position, transform.position);
        if (dist < 1) dist = 1;

        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;
        Vector3 gravPull = gravDirection * (-planet.gravity/dist);

        GetComponent<Rigidbody>().AddForce(gravPull);

        
    }

    void ProcessGroundToEnemyInfo(){
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, transform.position-planet.transform.position, out hit, 15))
        {
            distanceToGround = hit.distance;
            groundNormal = hit.normal;

            if (distanceToGround <= 1f){
                isGrounded = true;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }else{
                isGrounded = false;
            }                        
        }
    }

    void UpdateGroundedMovement(){
    }

    // Update is called once per frame
    void Update()
    {
        ProcessGroundToEnemyInfo();

        if (!isGrounded){
            UpdateOrbitMovement();
        }else{
            UpdateGroundedMovement();
        }
        
    }
}
