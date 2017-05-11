using UnityEngine;
using System.Collections;

public class Portcullious_trap : MonoBehaviour
{
    private PlayerController player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider port)
    {
        if (port.gameObject.CompareTag("Player"))
        {
            player.takeDamage(2);
            StartCoroutine(player.Knockback(0.02f, 2550, player.transform.position, transform.position));
        }
    }
}
