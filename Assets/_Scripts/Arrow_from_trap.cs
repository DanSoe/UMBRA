using UnityEngine;
using System.Collections;

public class Arrow_from_trap : MonoBehaviour
{
    private PlayerController player;

    public float speed;
    public float lifetime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            player.takeDamage(1);
            StartCoroutine(player.Knockback(0.04f, 750, player.transform.position, transform.position));
        }
    }
}