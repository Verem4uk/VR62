using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableValues : MonoBehaviour
{
    [SerializeField]
    Text[] green1;

    [SerializeField]
    Text[] green2;

    [SerializeField]
    Text[] green3;

    [SerializeField]
    Text[] yellow1;

    [SerializeField]
    Text[] yellow2;

    [SerializeField]
    Text[] yellow3;

    [SerializeField]
    Text[] red1;

    [SerializeField]
    Text[] red2;

    [SerializeField]
    Text[] red3;

    [SerializeField]
    Text[] blue1;

    [SerializeField]
    Text[] blue2;

    [SerializeField]
    Text[] blue3;

    [SerializeField]
    Text Rtext;

    [SerializeField]
    Text textInput;

    [SerializeField]
    Text describeInput;

    Text[][] matrix = new Text[12][];

    float R;

    const float y = 0.0283f;//мм

    void Start()
    {
        matrix[0] = green1;
        matrix[1] = green2;
        matrix[2] = green3;
        matrix[3] = yellow1;
        matrix[4] = yellow2;
        matrix[5] = yellow3;
        matrix[6] = red1;
        matrix[7] = red2;
        matrix[8] = red3;
        matrix[9] = blue1;
        matrix[10] = blue2;
        matrix[11] = blue3;
    }

    public void WriteValue()
    {
       
        string valueText = textInput.text;
        int newValue = 0;
        
        if (int.TryParse(valueText, out newValue))
        {
            newValue *= 2;
        }
        else
        {
            textInput.text = "Введите целое число";
        }
        
        if (green1[0].text == "_")
        {
            //print("попали сюда" + " в инпуте " + valueText);
            if (EventManager.WriteValue()) green1[0].text = newValue.ToString();
            else return;

        }
        else if (green2[0].text == "_")
        {
            if (EventManager.WriteValue()) green2[0].text = newValue.ToString();
            else return;
        }
        else if (green3[0].text == "_")
        {
            if (EventManager.WriteValue()) green3[0].text = newValue.ToString();
            else return;
            CalculateR();
        }
        else 
        {       
            for(int i = 3; i<matrix.Length;i++)
            {
                if(matrix[i][0].text == "_")
                {
                    if (!EventManager.WriteValue()) return;

                    matrix[i][0].text = newValue.ToString();
                    float Dm = CalculateDm(newValue);
                    matrix[i][1].text = Dm.ToString("0.000");
                    float D2 = CalculateD2(Dm);
                    matrix[i][2].text = D2.ToString("0.000"); 

                    if (i == 5 || i==8 || i == 11)
                    {
                        int l = CalculateL(Convert.ToSingle(matrix[i - 2][2].text), Convert.ToSingle(matrix[i - 1][2].text), this.R);
                        for(int j = i-2; j<=i; j++)
                        {
                            matrix[j][3].text = l.ToString();
                        }
                    }
                    break;
                }
                
            }
            
                      
        }

        textInput.text="";
    }
   
    float CalculateDm(int Nm)
    {
        return Nm * y;//в мм
    }

    float CalculateD2(float Dm)
    {
        return Dm * Dm;  //в мм2      
    }

    void CalculateR()
    {
        float R = 0;
        for(int m=0; m<3; m++)
        {
            Text[] t = matrix[m];            
            float Dm = CalculateDm(Convert.ToInt32(t[0].text));            
            float Dm2 = CalculateD2(Dm);            
            float currentR = (Dm2) / (4 * (m + 1) * 0.000525f)/1000;//получим в мм        
            R += currentR;            
            t[1].text = Dm.ToString();
            t[2].text = Dm2.ToString();                   
        }
        R /= 3;
        this.R = R;
        this.Rtext.text = "R = " + R.ToString("0.00")+ "м";
    }

    int CalculateL(float D2ring1, float D2ring2, float R)
    {
        //print(D2ring2 / 1000000);
        float l = ((D2ring2 - D2ring1) / (4 * R /1000));
        return (int)(l);
    }


    public void Clean()
    {
        foreach (Text[] t in matrix)
        {
            for(int i = 0; i<t.Length; i++)
            {
                t[i].text = "_";
            }           

        }
    }
}
