using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterScript : MonoBehaviour
{
    int cnt = 0;
    public int GetTime()
    {
        return cnt / 100;
    }
    void Update()
    {
        //if(cnt > 500)
       // {
        //    TextScript.GameOver();
       // }
        //else
        //{
            //cnt++;
            //GameObject.Find("Counter text").GetComponent<TMP_Text>().text = (cnt / 100) + "." + (cnt % 100) + " secunde";
       // }
        
        
        
    }
}
