using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float initalImpulse;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Launch();
    }

    
    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float zVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        rb.AddForce(new Vector3(xVelocity,0,zVelocity) * initalImpulse, ForceMode.Impulse);
        Debug.Log(new Vector3(xVelocity, 0, zVelocity));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalPlayer"))
        {
            gameManager.Instance.PlayerScored();
            gameManager.Instance.Restart();
            Launch();
        }
        else if (other.gameObject.CompareTag("GoalIA"))
        {
            gameManager.Instance.IaScored();
            gameManager.Instance.Restart();
            Launch();
        }
    }
}
