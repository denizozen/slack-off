using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionistScript : MonoBehaviour
{
    private bool play = false;
    public GameObject receptOff;
    public GameObject player;
    private Transform playerTransform;
    private Animator playerAnim;
    private Animator receptAnim;

    void Start()
    {
        playerTransform = player.transform;
        playerAnim = player.GetComponent<Animator>();
        receptAnim = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && gameObject.tag == "interactable")
        {
            play = true;
            receptOff.gameObject.SetActive(true);
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (play)
        {
            MyCharacterScript.funMeter += 20;
            gameObject.transform.LookAt(playerTransform);
            playerAnim.SetTrigger("talkingMarta");
            receptAnim.SetTrigger("isTalking");
            gameObject.tag = "done";
            play = false;
        }
    }
}
