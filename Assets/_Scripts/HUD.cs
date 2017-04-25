using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
    
    //public Animator[] HeartAnimations;

    Animator HeartUI;

    private PlayerController player;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        HeartUI = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        HeartUI.SetFloat("CurHealth", player.curHealth);
	
	}
}
