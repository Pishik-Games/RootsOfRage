using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyScript
{
    public GameObject player;

    public float movementSpeed;

    private Rigidbody enemyRigidBody;

    private void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player

        
        //transform.position += (player.transform.position - transform.position) * movementSpeed * Time.deltaTime;

        enemyRigidBody.velocity = (player.transform.position - transform.position) * movementSpeed * Time.deltaTime;
        transform.LookAt(
            new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z)
            );
    }
}
