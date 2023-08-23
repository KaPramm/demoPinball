using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }
}
