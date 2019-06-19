using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotate : MonoBehaviour
{

    float minAngle = 15f;
    float maxAngle = 105f;

    float previousAngle;

float curentRotation = 105f;	

    private void Start()
    {
        EventManager.ChangeColor(Color.red);
    }
    
   void OnMouseDown()
    {
        print("клик обработан");
        curentRotation -= 20;
        CalculalteAngle(curentRotation);
    }
    
    void CalculalteAngle(float angle)
    {
        if (angle < 15) 
{angle = 105;
curentRotation = 105;
}
            transform.localEulerAngles = new Vector3(0, -90, angle);
            previousAngle = angle;
            EventManager.ChangeColor(CalculateColor(angle));
      


        // EventManager.ChangeColor()
    }

    Color CalculateColor(float angle)
    {
        print("angle "+angle);
        switch (angle)
        {
 
            case 25: return Color.white;
            case 45: return Color.blue;
            case 65: return Color.yellow;
            case 85: return Color.green;
            case 105: return Color.red;
            default: return Color.white;

        }
    }

}
