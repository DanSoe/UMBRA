using UnityEngine;
using System.Collections;

public class knightController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody body;

    Animator Anim;

    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetFloat("Speed", moveSpeed);
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
