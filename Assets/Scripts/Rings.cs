using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rings : MonoBehaviour
{
    [SerializeField]
    new Image ring1;

    [SerializeField]
    new Image ring2;

    [SerializeField]
    new Image ring3;

    const float R = 0.5f;
    const float y = 28.3f;//мкм

    enum LightsLength
    {
        Red = 700,
        Yellow = 575,
        Green = 525,
        Blue = 450
    }

    private void OnEnable()
    {
        EventManager.ColorChanger += ChangeRings;
        //EventManager.Switch += Render;
    }

    void ChangeRings(Color color)
    {
        if (color == Color.red)
        {
            ChangeSize(ring1, CalculateSize(LightsLength.Red, 1));
            ChangeSize(ring2, CalculateSize(LightsLength.Red, 2));
            ChangeSize(ring3, CalculateSize(LightsLength.Red, 3));            
        }

        if (color == Color.yellow)
        {
            ChangeSize(ring1, CalculateSize(LightsLength.Yellow, 1));
            ChangeSize(ring2, CalculateSize(LightsLength.Yellow, 2));
            ChangeSize(ring3, CalculateSize(LightsLength.Yellow, 3));
        }

        if (color == Color.green)
        {
            ChangeSize(ring1, CalculateSize(LightsLength.Green, 1));
            ChangeSize(ring2, CalculateSize(LightsLength.Green, 2));
            ChangeSize(ring3, CalculateSize(LightsLength.Green, 3));
        }

        if (color == Color.blue)
        {
            ChangeSize(ring1, CalculateSize(LightsLength.Blue, 1));
            ChangeSize(ring2, CalculateSize(LightsLength.Blue, 2));
            ChangeSize(ring3, CalculateSize(LightsLength.Blue, 3));
        }        
    }

    void ChangeSize(Image ring, float value)
    {
        ring.rectTransform.offsetMin = new Vector2(value, value);
        ring.rectTransform.offsetMax = new Vector2(-value, -value);
    }


    float CalculateSize(LightsLength l, int numberOfRing)
    {     
        float value = (Mathf.Sqrt(numberOfRing * R * 1000000 * (float)l/1000)) / y;
       // print(value);
        //print(l + numberOfRing.ToString()+"Значение радиуса в делениях " + value);

        switch (numberOfRing)
        {
            //пересчитать!!!
            case 1:
                {
                    float valueInPersent = EventManager.ToPersent(17, 21, value);
                   // print("значение процента" + valueInPersent);
                    float valueRect = EventManager.FromPersent(223, 185, valueInPersent);
                    //print("Значение отступа" +valueRect);
                    return valueRect;                    
                }
            case 2:
                {
                    float valueInPersent = EventManager.ToPersent(24, 30, value);
                    float valueRect = EventManager.FromPersent(175, 120, valueInPersent);
                    //print("Значение отступа" + valueRect);
                    return valueRect;
                }
            case 3:
                {
                    float valueInPersent = EventManager.ToPersent(29, 36, value);
                    float valueRect = EventManager.FromPersent(23, -50, valueInPersent);
                    //print("Значение отступа" + valueRect);
                    return valueRect;
                }
        }
        return 0;
        
    }

}
