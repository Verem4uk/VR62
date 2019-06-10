using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButtonTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private Info infoData;

    MaterialChanger joinObject;

    [SerializeField]
    TextPanel Panel;

  // private Text text;

    void Start()
    {
        //text = GetComponentInChildren<Text>();
        joinObject = GetComponent<MaterialChanger>();
    }
    public void OnPointerEnter(PointerEventData eventData)//смотрим на объект
    {
        if(joinObject!=null) joinObject.HighLightObject();
/*
        if (infoData != null)
        {
           // if (infoData.GetImage() != null) Panel.Open(infoData.GetImage());
            else Panel.Open(infoData.GetInfo());
        }
        else
            Panel.Open("");
            */
    }

    public void OnPointerExit(PointerEventData eventData)//отвели взгляд
    {
        PointerOut();
    }

    public void PointerOut()
    {
        if(joinObject!=null) joinObject.BackMaterials();
        Panel.Close();
    }
}
