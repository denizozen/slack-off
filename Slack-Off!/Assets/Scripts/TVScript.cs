using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TVScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject player;
    public GameObject cube;
    public GameObject tvOff;
    public Transform lookHere;
    private Transform cubeT;
    private Animator playerAnim;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        cubeT = cube.GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        playerAnim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.hour == 16 && TimeManager.minute == 45)
        {
            anim.SetTrigger("watchTv");
            agent.SetDestination(cubeT.position);
        }
        if (Input.GetKeyDown(KeyCode.X) && cube.gameObject.tag == "interactable")
        {
            MyCharacterScript.funMeter += 20;
            tvOff.gameObject.SetActive(true);
            anim.SetTrigger("talking");
            playerAnim.ResetTrigger("coolerTalk");
            playerAnim.SetTrigger("coolerTalk");
            cube.gameObject.tag = "done";
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "tv")
        {
            transform.LookAt(lookHere);
            anim.SetTrigger("wait");
            other.gameObject.tag = "interactable";
        }
    }

}
