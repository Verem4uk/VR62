using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotate : MonoBehaviour
{

    float minAngle = 15f;
    float maxAngle = 105f;

    float previousAngle;

    private void Start()
    {
        EventManager.ChangeColor(Color.red);
    }
    
   void OnMouseDown()
    {
        print("клик обработан");
        float newz = transform.eulerAngles.z - 20;
        CalculalteAngle(newz);
    }
    
    void CalculalteAngle(float angle)
    {
        if (angle < 15) angle = 105;
            transform.localEulerAngles = new Vector3(0, -90, angle);
            previousAngle = angle;
            EventManager.ChangeColor(CalculateColor(angle));
       


        // EventManager.ChangeColor()
    }

    Color CalculateColor(float angle)
    {
        switch ((int)angle)
        {
            case 20: return Color.white;
            case 40: return Color.blue;
            case 60: return Color.yellow;
            case 80: return Color.green;
            case 100: return Color.red;
            default: return Color.white;

        }
    }

}
