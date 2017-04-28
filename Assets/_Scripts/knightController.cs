using UnityEngine;
using System.Collections;

public class knightController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody body;

    public GameObject target;

    public float eneDist;
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

        if (target != null)
        {
            eneDist = Vector3.Distance(body.position, target.transform.position);

            if (eneDist < 5f)
            {
                Anim.SetBool("Attack", true);
                Anim.SetFloat("Speed", 0f);
            }
            if (eneDist > 5f)
            {
                Anim.SetBool("Attack", false);
                Anim.SetFloat("Speed", moveSpeed);
            }
        }
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
