using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

// записка, для поднятия нужно нажать клавишу, надпись уведомляющая что ее можно нажать появится при столкновении BC, внутри есть панель(картинка) на ней размещается текст, для этого в картинке есть еще text(legasy) с сообщением
public class Note : MonoBehaviour
{
    public string noteTextstr;
    public GameObject notice;
    public GameObject noteUI;
    public Text text;
  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        text.text = noteTextstr;
        if (Input.GetKey(KeyCode.E))
        {
            noteUI.SetActive(true);
        }
        if (Input.GetKey(KeyCode.T))
        {
            noteUI.SetActive(false);
        }
        notice.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        notice.SetActive(false);
        noteUI.SetActive(false);
    }
}
