using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{
    public float speed;

    private int direction = 1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * direction * Time.deltaTime);

    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            speed = 0;
            direction = 0;
        }
        if (other.tag == "Player")
        {
            speed = 10;
        }
    }
     /*
    void OnCollisionEnter(Collision coli)
    {
        if(coli.gameObject.CompareTag("Player"))
        {
            
            
        }
    }
      * */
}
