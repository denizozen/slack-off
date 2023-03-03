using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingScript : MonoBehaviour
{
    private bool play = false;
    public GameObject player;
    private Animator anim;

    void Start()
    {
        anim = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && gameObject.tag == "meeting")
        {
            play = true;
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (play)
        {
            if (MyCharacterScript.funMeter >= 50)
            {
                MyCharacterScript.funMeter -= 50;
            }
            else
            {
                MyCharacterScript.funMeter = 0;
            }
            anim.SetTrigger("isMeeting");
            gameObject.tag = "done";
            play = false;
            MyCharacterScript.notWorking = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        MyCharacterScript.notWorking = true;
    }

}
