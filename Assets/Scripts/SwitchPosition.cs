using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPosition : MonoBehaviour {


    float minAngle = 120;
    float maxAngle = 210;

    float speed = 5f;

    float currentAngle = 120; 


    private enum State 
        {
        off,
        on,
        turnToOff,
        turnToOn
        }

    State state = State.off;

    void OnEnable()//при включении/содании объекта
    {
        EventManager.Switch += ChangeState;//подписались на событие 
    }
  
    void ChangeState(bool work)
    {
        if (work && state == State.off) state = State.turnToOn;
        else if (!work && state == State.on) state = State.turnToOff;
    }

    void FixedUpdate()
    {
        
        if (state == State.turnToOn)
        {
            currentAngle += speed;
            if (currentAngle < maxAngle)
            {

                transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.right);
            }
            else state = State.on;

        }

        if (state == State.turnToOff)
        {

            currentAngle -= speed;
            if (currentAngle > minAngle)
            {
                transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.right);
            }
            else state = State.off;
            
        }
    }
    
}




