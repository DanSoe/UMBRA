using UnityEngine;
using System.Collections;

public class knightController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody body;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        body.velocity = transform.forward * moveSpeed;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "edge")
        {
            body.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
        }
    }
}
