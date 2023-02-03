using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float movementSpeed;
    public GameObject mainCamera;

    public Vector3 moveTowards;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyDelayed), 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementSpeed * Time.deltaTime * moveTowards;
        transform.LookAt(mainCamera.transform.position);
    }

    void DestroyDelayed()
    {
        Destroy(gameObject);
    }
}
