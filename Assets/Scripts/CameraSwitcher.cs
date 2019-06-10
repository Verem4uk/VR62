using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject okylar;
    
    [SerializeField]
    GameObject rings;

    [SerializeField]
    GameObject main;

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
        rings.SetActive(false);
    }

    private void Update()
    {
        //print(Vector3.Distance(gameObject.transform.position, okylar.transform.position));
        if(!into && Vector3.Distance(gameObject.transform.position, okylar.transform.position)<2)
        {
            Switch(false);
        }
        
       else if(into && Vector3.Distance(gameObject.transform.position, okylar.transform.position) > 2)
        {
            Switch(true);
        }
    }

    public void Switch(bool onMain)
    {
        
        print("вызван switch c "+onMain);
        if (onMain)
        {
            print("переключаемся на главную");
            //main.SetActive(true);
            rings.SetActive(false);
            into = false;
        }

        else
        {
            print("переключаемся с главной");
            //main.SetActive(false);
            rings.SetActive(true);
            into = true;
        }
       
    }
    
}
