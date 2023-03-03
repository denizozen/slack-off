using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyCharacterScript : MonoBehaviour
{
  public static bool notWorking = true;
  public Image textBox;
  public Text text;
  public GameObject tv,coffee,recept,video,cooler;
  private Animator anim;
  public Transform bossTransform;
  public static float funMeter = 0;
  public Slider slider;
  private CharacterController charc;
  public GameObject bustedAlarm;
  private float timer = 0;

  void Start()
  {
    anim = gameObject.GetComponent<Animator>();
  }
  void Update()
  {
    Debug.Log(funMeter);
    slider.value = funMeter;
    if (Input.GetKeyDown(KeyCode.M))
    {
      work();
    }

    if (Input.GetKeyDown(KeyCode.N))
    {
      stopWork();
    }

    if (!notWorking)
    {
      timer += Time.deltaTime;
      if (timer >= 3f)
      {
        funMeter -= 1;
        timer = 0;
      }
    }
  }
  
  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("toiletdoor"))
    {
      text.text = "Maybe I can watch some videos on the toilet without being disturbed!";
      StartCoroutine(TextBoxEffect(text));
      video.gameObject.SetActive(true);
      other.gameObject.tag = "interactable";
      
    }
    if (other.CompareTag("receptionist"))
    {
      text.text = "Maybe I can talk to the Receptionist Marta for a while!";
      StartCoroutine(TextBoxEffect(text));
      recept.gameObject.SetActive(true);
      other.gameObject.tag = "interactable";
    }
    if (other.CompareTag("watercooler"))
    {
      text.text = "Maybe I can talk to Jo near the water cooler!";
      StartCoroutine(TextBoxEffect(text));
      cooler.gameObject.SetActive(true);
      other.gameObject.tag = "interactable";
    }
    if (other.CompareTag("tv"))
    {
      text.text = "Maybe I can watch some TV with Marco for a while!";
      StartCoroutine(TextBoxEffect(text));
      tv.gameObject.SetActive(true);
    }
    if (other.CompareTag("coffee"))
    {
      text.text = "Maybe I can drink some coffee!";
      StartCoroutine(TextBoxEffect(text));
      coffee.gameObject.SetActive(true);
      other.gameObject.tag = "interactable";
    }
    
    if (other.CompareTag("meetingText"))
    {
      text.text = "Maybe I can join this meeting!";
      StartCoroutine(TextBoxEffect(text));
      other.gameObject.tag = "done";
    }

    if (other.CompareTag("boss") && BossScript.busted)
    {
      other.transform.LookAt(gameObject.transform);
      BossScript.anim.SetBool("yell",true);
    }
  }

  IEnumerator TextBoxEffect(Text newText)
  {
    textBox.gameObject.SetActive(true);
    text = newText;
    yield return new WaitForSeconds(5);
    textBox.gameObject.SetActive(false);

  }

  void work()
  {
    anim.SetBool("isWorking",true);
    notWorking = false;
    bustedAlarm.gameObject.SetActive(false);
  }

  void stopWork()
  {
    anim.SetBool("isWorking", false);
    notWorking = true;
  }

}
