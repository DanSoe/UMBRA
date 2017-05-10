using UnityEngine;
using System.Collections;

public class Arrow_Trap : MonoBehaviour
{
    public GameObject Arrow;
    public Transform arrowSpawn;

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider trap)
    {
        if(trap.gameObject.CompareTag("Player"))
        {
            Instantiate(Arrow, arrowSpawn.position, arrowSpawn.rotation);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
