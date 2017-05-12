using UnityEngine;
using System.Collections;

public class ghoulAttack : MonoBehaviour {


    private PlayerController player;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider hands)
    {
        if (hands.gameObject.CompareTag("Player"))
        {
            player.takeDamage(1);
            StartCoroutine(player.Knockback(0.02f, 1750, player.transform.position, transform.position));
        }
    }
}