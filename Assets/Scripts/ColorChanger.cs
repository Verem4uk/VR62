using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    new Image renderer;
    Color memoryColor;

    private void OnEnable()
    {
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
        }
        else renderer.color = Color.black;

    }
    
    void ChangeColor(Color color)
    {
        print(renderer.enabled);
        if (renderer.enabled == true)
        {
            print("красим");
            renderer.color = color;
        }
        memoryColor = color;
    }
}
