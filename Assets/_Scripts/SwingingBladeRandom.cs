using UnityEngine;
using System.Collections;

public class SwingingBladeRandom : MonoBehaviour
{
    Animator swing;

    void Start()
    {
        swing = GetComponent<Animator>();

        swing.Play("Swing", 0, Random.value);

    }
}
