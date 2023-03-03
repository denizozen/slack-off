using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    private float speed = 5.0f;
    public Transform cubeInMiddle;
    public NavMeshAgent agent;
    public static Animator anim;
    public static bool busted;
    private IEnumerator co;
    public GameObject bustedAlarm;
    public Material mat;
    void Start()
    {
        mat.color = Color.white;
        co = Patrol();
        anim = GetComponent<Animator>();
        StartCoroutine(co);
    }

    IEnumerator Patrol()
    {
        float myTime = Time.time;
        while (true)
        {
            if (Time.time - myTime > 90)
            {
                bustedAlarm.SetActive(true);
                anim.SetBool("isPatrol", true);
                anim.SetBool("isWalking", true);
                for (int i = 0; i < 7;++i)
                {
                    String x = i.ToString();
                    agent.SetDestination(GameObject.FindWithTag(x).GetComponent<Transform>().position);
                    transform.LookAt(cubeInMiddle);
                    yield return new WaitForSeconds(10);
                    transform.rotation = Quaternion.LookRotation(agent.steeringTarget);
                }
                myTime = Time.time;
            }
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("workCube"))
        {
            Scan();
        }
    }
    
    void Scan()
    {
        if (MyCharacterScript.notWorking)
        {
            busted = true;
            mat.color = Color.red;
            anim.SetBool("busted",true);
            StopCoroutine(co);
            StartCoroutine("EndGame");
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("GameOver");
    }
}
