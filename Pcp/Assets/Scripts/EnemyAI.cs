using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float fpsTargetDistance;
    public float enemylookDistance;
    public float atackDistance;
    public float enemymovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody theRigidbody;
    Renderer myRender;



	// Use this for initialization
	void Start () {
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position,transform.position);
        if (fpsTargetDistance < enemylookDistance) {
            lookAtPlayer();
        }

        if (fpsTargetDistance < atackDistance)
        {
            myRender.material.color = Color.red;
            attackPlease();
        }
        else{
            myRender.material.color = Color.blue;
        }
    }
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
    void attackPlease()
    {
        theRigidbody.AddForce(transform.forward * enemymovementSpeed);
    }
}
