using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;

    private float zBound = 73f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Vertical");

        Vector3 playerPosition = transform.position;    
        playerPosition.z = Mathf.Clamp(playerPosition.z + movement * speed * Time.deltaTime, -zBound, zBound);
        transform.position = playerPosition;
    }
}
