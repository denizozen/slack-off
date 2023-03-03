using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeScript : MonoBehaviour
{
        private bool play = false;
        public GameObject coffeeOff;
        public GameObject mug;
        public Animator anim;

        void Start()
        {
        }
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
                coffeeOff.gameObject.SetActive(true);
                mug.gameObject.SetActive(true);
                MyCharacterScript.funMeter += 20;
                anim.SetTrigger("play");
                gameObject.tag = "done";
                play = false;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (!play)
            {
                mug.gameObject.SetActive(false);
            }
        }

}
