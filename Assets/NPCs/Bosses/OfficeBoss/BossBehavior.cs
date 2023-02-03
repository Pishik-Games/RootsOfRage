using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject[] smallFohsh;
    public GameObject enemyFollower;
    public GameObject mainCamera;
    public GameObject player;

    public int numberOfProjectiles;
    public int numberOfEnemyFollower;
    public int health = 4;
    public float degrees = 10f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(MakeProjectiles), 2, 1f);

        InvokeRepeating(nameof(MakeEnemyFollow), 2, 20f);
    }

    // Update is called once per frame
    void Update(){
        transform.LookAt(player.transform.position);
    }

    void MakeEnemyFollow(){
        for(int i = 0; i < numberOfEnemyFollower ; i++){

            GameObject newEnemy = Instantiate(enemyFollower);
            newEnemy.name = "EnemyFollower";

            newEnemy.GetComponent<EnemyFollow>().player = player;
            newEnemy.transform.position = (transform.position + new Vector3(0, 0, 0));
        }
    }

    void MakeProjectiles()
    {
        Vector3 directionTowardsPlayer = (
                new Vector3(player.transform.position.x, 0, player.transform.position.z) -
                new Vector3(transform.position.x, 0, transform.position.z)
                ).normalized;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            int offset;

            GameObject newProjectile = Instantiate(smallFohsh[Random.Range(0, smallFohsh.Length - 1)]);

            offset = i - ((numberOfProjectiles) / 2);

            Quaternion rotation = Quaternion.Euler(0, degrees * offset, 0);

            Vector3 newDirection = rotation * directionTowardsPlayer;

            newProjectile.GetComponent<Projectile>().mainCamera = mainCamera;
            newProjectile.GetComponent<Projectile>().moveTowards = newDirection.normalized;
            newProjectile.transform.position = (transform.position + new Vector3(0, 0, 0));
            
        }
    }

    public void getPunch()
    {
        if (health != 1)
        {
            health--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
