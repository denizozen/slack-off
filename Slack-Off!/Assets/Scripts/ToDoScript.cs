using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoScript : MonoBehaviour
{
    public Button todo;
    public GameObject todoList;
    private bool clicked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = todo.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (clicked == false)
        {
            todoList.SetActive(true);
            clicked = true;
        }
        else
        {
            todoList.SetActive(false);
            clicked = false;
        }
        
    }
}
