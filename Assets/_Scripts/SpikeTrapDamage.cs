using UnityEngine;
using System.Collections;

public class SpikeTrapDamage : MonoBehaviour
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
    void OnTriggerEnter(Collider spikedmg)
    {
        if (spikedmg.gameObject.CompareTag("Player"))
        {
            player.takeDamage(1);
            StartCoroutine(player.Knockback(0.02f, 2550, player.transform.position, transform.position));
        }
    }
}
