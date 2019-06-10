using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeByCursor : MonoBehaviour {
    
    MaterialChanger changer;//смена материал

    [SerializeField]
    private Info infoData;//скриптабл инфо

    [SerializeField]
    Text infoText;//для смены текста информационной панели

    private void Start()
    {
        //Cursor.SetCursor(startcursor, Vector2.zero, cursorMode);
        changer = GetComponent<MaterialChanger>();
    }
    
    void OnMouseEnter()//навели мышь/посмотрели
    {
        changer.HighLightObject();//подсветили объект
        infoText.text = infoData.GetInfo();//обновили информацию
    }

    void OnMouseExit()
    {        
        changer.BackMaterials();
    }

}

