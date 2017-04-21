using UnityEngine;
using System.Collections;

public class Arrow_from_trap : MonoBehaviour
{
    public float speed;
    public float lifetime;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
}