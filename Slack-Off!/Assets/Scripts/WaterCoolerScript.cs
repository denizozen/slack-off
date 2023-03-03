using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaterCoolerScript : MonoBehaviour
{
    private Animator anim;
    public Transform cooler;
    public Transform desk;
    public GameObject player;
    private Transform playerTransform;
    private Animator playerAnim;
    public GameObject coolerOff;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        playerTransform = player.GetComponent<Transform>();
        playerAnim = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (TimeManager.hour == 15 && TimeManager.minute == 45)
        {
            StartCoroutine("CoolerTalk");
        }
        
        if (TimeManager.hour == 16 && TimeManager.minute == 10 || gameObject.CompareTag("done"))
        {
            StartCoroutine("BackToWork");
        }

        if (Input.GetKeyDown(KeyCode.X) && gameObject.tag == "interactable")
        {
            StartCoroutine("TalktoMC");
            coolerOff.gameObject.SetActive(true);
        }
    }

    IEnumerator CoolerTalk()
    {
        anim.SetTrigger("started");
        gameObject.transform.LookAt(cooler);
        yield return new WaitForSeconds(3f);
        gameObject.tag = "watercooler";
    }

    IEnumerator BackToWork()
    {
        anim.SetTrigger("finished");
        gameObject.transform.LookAt(desk);
        yield return null;
    }

    IEnumerator TalktoMC()
    {
        MyCharacterScript.funMeter += 20;
        anim.SetTrigger("talking");
        playerAnim.SetTrigger("coolerTalk");
        gameObject.transform.LookAt(playerTransform);
        yield return new WaitForSeconds(41f);
        gameObject.tag = "done";
    }
    
}
