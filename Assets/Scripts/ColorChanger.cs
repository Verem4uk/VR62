using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    new Image renderer;
    Color memoryColor;
    bool working;

    private void OnEnable()
    {
        print("сработал enable");
       EventManager.Switch += Render;
    }

    void Start()
    {
        print(renderer.enabled);
        EventManager.ColorChanger += ChangeColor;//подписываемся на событие для переключения камер
        print(renderer.enabled);
    }
    
    private void Render(bool work)
    {

        if (work)
        {
            renderer.color = memoryColor;
            working = true;
        }
        else
        {
            renderer.color = Color.black;
            working = false;
        }

    }
    
    void ChangeColor(Color color)
    {
        print("вызвана смена цвета");
        print(renderer.enabled);
        if (working)
        {
           // print("красим");
            renderer.color = color;
        }
        memoryColor = color;
    }
}
