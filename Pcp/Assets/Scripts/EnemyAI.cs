using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float fpstargetDistance;
    public float enemylookDistance;
    public float atackDistance;
    public float enemymovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody therigidbody;
    Renderer myRender;



	// Use this for initialization
	void Start () {
        myRender.GetComponent<Renderer>();
        therigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void fixedUpdate () {
        fpstargetDistance = Vector3.Distance(fpsTarget.position,transform.position);
        if (fpstargetDistance < enemylookDistance)
        {
            myRender.material.color = Color.yellow;
            lookAtPlayer();
            print("Look at the player pls.");
        }

    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
