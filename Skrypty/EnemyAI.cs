using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    GameObject player;
    PlayerHealth playerHealth;


    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;

   

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    Rigidbody theRigidbody;
    Renderer myRender;
	// Use this for initialization
   
	void Awake () {
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
        // playerHealth = playerHealth.GetComponent<PlayerHealth>();
       
    }
    


    void FixedUpdate()
    {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);

        if (fpsTargetDistance < enemyLookDistance)
        {
            lookAtplayer();
            // print("Look");
        }
        if (fpsTargetDistance < attackDistance)
        {
            myRender.material.color = Color.black;
            attack();

        }
        else myRender.material.color = Color.white;

    }

    void lookAtplayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void attack()
    {
        theRigidbody.MovePosition(theRigidbody.position + transform.forward * enemyMovementSpeed);
               
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            print("atak");
         

        }
    }
   
}
