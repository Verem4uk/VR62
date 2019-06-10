using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour {

    [SerializeField]
    Text taskText;
    Image myimage;

    [SerializeField]
    Button addButton;
    [SerializeField]
    Image addButtonImage;

    [SerializeField]
    Button tableButton;
    [SerializeField]
    Image tableButtonImage;
    [SerializeField]

    Button clearTableButton;
    [SerializeField]
    Image clearTableButtonImage;

    [SerializeField]
    GameObject inputArea;

    bool isWorking;
    Color currentColor;

    private void Start()
    {
        myimage = GetComponent<Image>();        
        myimage.enabled = false;
        taskText.enabled = false;
        addButton.GetComponent<Image>().enabled = false;
        tableButton.GetComponent<Image>().enabled = false;
        clearTableButton.GetComponent<Image>().enabled = false;
        addButtonImage.enabled = false;
        tableButtonImage.enabled = false;
        clearTableButtonImage.enabled = false;
        inputArea.SetActive(false);


        taskText.text = "Включите установку";
        
        EventManager.Switch += WorkingControl;
        EventManager.ColorChanger += ColorControl;

        EventManager.Switch += Task1;
    }
      
    void WorkingControl(bool work)//постоянно отслеживаем включена ли установка
    {
        isWorking = work;
        print("isWorking switch to " + work);
    }

    void ColorControl(Color color)
    {
        currentColor = color;
    }
    //введение
    void Task1(bool w)
    {
        if (w)
        {
            EventManager.Switch -= Task1;
            taskText.text = "Поворотом барабана, установите зеленый светодиод!";
            EventManager.ColorChanger += Task2;
            Open();
        }
    }
    
    void Task2(Color color)
    {
        if (color == Color.green)
        {
            EventManager.ColorChanger -= Task2;
            taskText.text = "Посмотрите в окуляр микроскопа";
            EventManager.SwitchCan += Task3;
            Open();
        }
    }
    
    void Task3(bool mainView)
    {
        if (!mainView && isWorking)
        {
            EventManager.SwitchCan -= Task3;
            taskText.text = "Впишите в таблицу радиус первого кольца в малых делениях";
            EventManager.WritingValue += Task4;
            Open();
        }
    }

    //зеленый свет
    bool Task4()
    {
        if (TaskControl(Color.green, "зелёный"))
        {
            EventManager.WritingValue -= Task4;
            taskText.text = "Впишите в таблицу радиус второго кольца в малых делениях";
            EventManager.WritingValue += Task5;
            Open();
            return true;
        }
        else return false;
    }

    bool Task5()
    {
        if (TaskControl(Color.green ,"зелёный"))
        {
            EventManager.WritingValue -= Task5;
            taskText.text = "Впишите в таблицу диметр третьего кольца в малых делениях";
            EventManager.WritingValue += Task6;
            Open(); return true;
        }
        else return false;
    }

    bool Task6()
    {
        if (TaskControl(Color.green, "зелёный"))
        {
            EventManager.WritingValue -= Task6;
            taskText.text = "Значение радиуса кривизны линзы можно увидеть в таблице, теперь включите жёлтый свет";
            EventManager.ColorChanger += Task7;
            Open();
            return true;
        }
        else return false;
    }

    //желтый свет
    void Task7(Color color)
    {
        if (color == Color.yellow)
        {
            EventManager.ColorChanger -= Task7;
            taskText.text = "Впишите в таблицу радиуса первого кольца в малых делениях";
            EventManager.WritingValue += Task8;
            Open();
        }
    }

    bool Task8()
    {
        if (TaskControl(Color.yellow, "жёлтый"))
        {
            EventManager.WritingValue -= Task8;
            taskText.text = "Впишите в таблицу радиус второго кольца в малых делениях";
            EventManager.WritingValue += Task9;
            Open(); return true;
        }
        else return false;
    }

    bool Task9()
    {
        if (TaskControl(Color.yellow, "жёлтый"))
        {
            EventManager.WritingValue -= Task9;
            taskText.text = "Впишите в таблицу радиус третьего кольца в малых делениях";
            EventManager.WritingValue += Task10;
            Open();
            return true;
        }
        else return false;
    }
    
    bool Task10()
    {
        if (TaskControl(Color.yellow, "жёлтый"))
        {

            EventManager.WritingValue -= Task10;
            taskText.text = "Включите красный свет";
            EventManager.ColorChanger += Task11;
            Open();
            return true;
        }
        else return false;
    }

    //красный цвет
    void Task11(Color color)
    {
        if (color == Color.red)
        {
            EventManager.ColorChanger -= Task11;
            taskText.text = "Впишите в таблицу радиус первого кольца в малых делениях";
            EventManager.WritingValue += Task12;
            Open();
        }
    }

    bool Task12()
    {
        if (TaskControl(Color.red, "красный"))
        {
            EventManager.WritingValue -= Task12;
            taskText.text = "Впишите в таблицу радиус второго кольца в малых делениях";
            EventManager.WritingValue += Task13;
            Open();
            return true;
        }
        else return false;
    }

    bool Task13()
    {
        if (TaskControl(Color.red, "красный"))
        {

            EventManager.WritingValue -= Task13;
            taskText.text = "Впишите в таблицу радиус третьего кольца в малых делениях";
            EventManager.WritingValue += Task14;
            Open();
            return true;
        }
        else return false;
    }

    bool Task14()
    {
        if (TaskControl(Color.red, "красный"))
        {

            EventManager.WritingValue -= Task14;
            taskText.text = "Включите синий свет";
            EventManager.ColorChanger += Task15;
            Open();
            return true;
        }
        else return false;
    }

    //синий цвет
    void Task15(Color color)
    {
        if (TaskControl(Color.blue, "синий"))
        {
            EventManager.ColorChanger -= Task15;
            taskText.text = "Впишите в таблицу радиус первого кольца в малых делениях";
            EventManager.WritingValue += Task16;
            Open();
        }
    }

    bool Task16()
    {
        if (TaskControl(Color.blue, "синий"))
        {
            EventManager.WritingValue -= Task16;
            taskText.text = "Впишите в таблицу радиус второго кольца в малых делениях";
            EventManager.WritingValue += Task17;
            Open();
            return true;
        }
        else return false;
    }

    bool Task17()
    {
        if (TaskControl(Color.blue, "синий"))
        {
            EventManager.WritingValue -= Task17;
            taskText.text = "Впишите в таблицу радиус третьего кольца в малых делениях";
            EventManager.WritingValue += Task18;
            Open();
            return true;
        }
        else return false;
    }

    bool Task18()
    {
        if (TaskControl(Color.blue, "синий"))
        {
            EventManager.WritingValue -= Task18;
            taskText.text = "Отлично, ознакомтесь с результатами измерений в таблице";
            Open();
            return true;
        }
        else return false;
    }

    bool TaskControl(Color color, string rusNameOfColor)
    {
        if (!isWorking)
        {
            string temporaryText = taskText.text;
            taskText.text = "Включите установку, а затем "+temporaryText;
            return false;
        }
        else if (color != null)
        {
            if (color == currentColor) return true;
            else
            {
                string temporaryText = taskText.text;
                taskText.text = "Включите "+ rusNameOfColor+" свет и "+temporaryText;
                return false;
            }
        }
        else return true;
    }


    public void Open()
    {
        myimage.enabled = true;
        taskText.enabled = true;
        addButton.GetComponent<Image>().enabled = true;
        tableButton.GetComponent<Image>().enabled = true;
        clearTableButton.GetComponent<Image>().enabled = true;
        addButtonImage.enabled = true;
        tableButtonImage.enabled = true;
        clearTableButtonImage.enabled = true;
        inputArea.SetActive(true);
    }

    public void Close()
    {
        myimage.enabled = false;
        taskText.enabled = false;
        addButton.GetComponent<Image>().enabled = false;
        tableButton.GetComponent<Image>().enabled = false;
        clearTableButton.GetComponent<Image>().enabled = false;
        addButtonImage.enabled = false;
        tableButtonImage.enabled = false;
        clearTableButtonImage.enabled = false;
        inputArea.SetActive(false);
    }
    public void ResetTasks()
    {
       // EventManager.Rotate -= Task2;
       // EventManager.Table -= Task3;
        EventManager.SwitchWork(false);
        taskText.text = "Включите установку";
        EventManager.Switch += Task1;
    }
   
}
