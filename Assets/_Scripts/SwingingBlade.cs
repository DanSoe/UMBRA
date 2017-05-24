using UnityEngine;
using System.Collections;

public class SwingingBlade : MonoBehaviour
{
    private PlayerController player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


    }
    void Update()
    {

    }
    void OnTriggerEnter(Collider blade)
    {
        if (blade.gameObject.CompareTag("Player"))
        {
            player.takeDamage(2);
            StartCoroutine(player.Knockback(0.02f, 2550, player.transform.position, transform.position));
        }
    }
}
