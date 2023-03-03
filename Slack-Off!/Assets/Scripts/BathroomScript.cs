using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BathroomScript : MonoBehaviour
{
    public GameObject timeline;
    private bool play = false;
    public GameObject bathOff;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && gameObject.tag == "interactable")
        {
            play = true;
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (play)
        {
            bathOff.gameObject.SetActive(true);
            MyCharacterScript.funMeter += 20;
            timeline.gameObject.SetActive(true);
            gameObject.tag = "done";
            play = false;
        }
    }
}
