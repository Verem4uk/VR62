using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    bool move = false;
    Vector3 startPosition;
    Vector3 needPosition = new Vector3(5.45f, 8, -22.6f);
    float speed = 0.01f;
    float offset = 0;
    Quaternion startRotation;
    Quaternion needRotaton = new Quaternion(0.7f, 0, 0, 0.7f);



    private void OnEnable()
    {
        EventManager.Moved += Move;
    }

    private void Move()
    {
        if(!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
        }
       
    }

    void FixedUpdate()
    {

        if(move)
        {
            offset+=speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            transform.rotation = Quaternion.Lerp(startRotation, needRotaton, offset);
            
            
            if (offset >= 1)
            {
                move = false;
                offset = 0;
                print("вызываем событие по окончанию движения");
                EventManager.SwitchCanvas(false);
            }
        }
    }
}
