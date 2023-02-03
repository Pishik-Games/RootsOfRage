using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;

    public GameObject player;
    Vector3 differencePosition;

    private void Start()
    {
        differencePosition = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (start) {
            start = false;
            StartCoroutine(Shaking());
        } else
        {
            transform.position = player.transform.position + differencePosition;
        }
    }

    IEnumerator Shaking() {
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = player.transform.position + differencePosition + Random.insideUnitSphere * strength;
            yield return null;
        }
    }
}
