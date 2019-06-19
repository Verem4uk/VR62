using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject okylar;

    [SerializeField]
    GameObject rings;

    Image[] intoCanvas;

    bool into;
    /*
    private void OnMouseDown()
    {
        //EventManager.MovedCamera();//вызываем событие для камеры для начала движения
        //EventManager.SwitchCan += Switch;//подписываемся на событие для переключения камер
    }
    */
    private void Start()
    {
        //print("вызвался старт");
        intoCanvas = rings.GetComponentsInChildren<Image>();
        foreach(Image img in intoCanvas)
        {
            //print(img.name);
        }
        Switch(true);
       
    }
    
    private void Update()
    {
        //print(Vector3.Distance(gameObject.transform.position, okylar.transform.position));
        if (!into && Vector3.Distance(gameObject.transform.position, okylar.transform.position) < 0.2f)
        {
            Switch(false);
        }

        else if (into && Vector3.Distance(gameObject.transform.position, okylar.transform.position) > 0.2f)
        {
            Switch(true);
        }
    }

    public void Switch(bool onMain)
    {
        
        //print("вызван switch c " + onMain);
        if (onMain)
        {
            print("переключаемся на главную");
            //main.SetActive(true);
            foreach (Image img in intoCanvas)
            {
                img.enabled = false;
            }
            into = false;
        }

        else
        {
           print("переключаемся с главной");
            //main.SetActive(false);
            foreach (Image img in intoCanvas)
            {
                img.enabled = true;
            }
            into = true;
        }

    }

}
