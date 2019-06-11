using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    new Image renderer;
    Color memoryColor;
    
    void OnEnable()
    {        
        EventManager.Switch += Render;
        EventManager.ColorChanger += ChangeColor;//подписываемся на событие для переключения камер
    }
   void Start()
    {
        renderer.enabled = false;
        print(renderer.enabled);
    }
    private void Render(bool work)
    {
        
        if (!work)
        {
            print("кольца выключились");
            renderer.enabled = false;
        }

        else
        {
            print("кольца включились");
            renderer.enabled = true;
            renderer.color = memoryColor;
        }
    }
    
    void ChangeColor(Color color)
    {

        if (renderer.enabled == true)
        {
            print("красим");
            renderer.color = color;
        }
        memoryColor = color;
    }
}
