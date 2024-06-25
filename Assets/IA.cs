using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public GameObject ball;
    public float speed = 10f;
    public float zLimit = 73f;

    void Update()
    {
        Vector3 direction = (ball.transform.position - transform.position).normalized;
        float move = direction.z * speed * Time.deltaTime;
        Vector3 newPos = transform.position + new Vector3(0, 0, move);

        // Clamp the position
        newPos.z = Mathf.Clamp(newPos.z, -zLimit, zLimit);
        transform.position = newPos;
    }
}
