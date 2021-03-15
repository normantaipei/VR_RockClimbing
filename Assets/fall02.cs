using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall02 : MonoBehaviour
{

    // public GameObject[] stone = new GameObject[20];
    public GameObject stone;
    public float left_blood = 100, right_blood = 100;
    public bool r_cost,l_cost;
    public bool r_cost_big, l_cost_big;
    public bool gamestart;
    int r_cooltime=0,l_cooltime=0;
    public bool win;
    public Vector3 fallspeed; 

    public GameObject wall;        //岩壁
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        gamestart = false;
        win = false;
        fallspeed = Vector3.up / 5;
       // r_grab = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        gamestart = stone.GetComponent<grab>().gamestart;
        //sDebug.Log(l_cost);
        
        if (r_cost) 
        {
            right_blood = right_blood - 0.1f;
            
        }
        else if(right_blood<=100)
        {
            right_blood = right_blood + 0.3f;
        }
        if (r_cost_big)
        {
            right_blood = right_blood - 0.5f;
        }

        if (l_cost)
        {
            left_blood = left_blood - 0.1f;
        }
        else if(left_blood<=100)
        {
            left_blood = left_blood + 0.3f;
        }
        if (l_cost_big)
        {
            left_blood = left_blood - 0.5f;
        }


        // Debug.Log(right_blood);
      
        if (wall.transform.position.y <= -14)
        {
            win = true;
            winText.SetActive(true);
        }

        Debug.Log(win);


        //體力判斷
        if (!win&&wall.transform.position.y<=0)
        {
            if (!r_cost && !l_cost && gamestart)
            {
                wall.transform.position += fallspeed;

            }
            if (!r_cost && left_blood <= 0)
            {
                wall.transform.position += fallspeed;
            }
            if (!l_cost && right_blood <= 0)
            {
                wall.transform.position += fallspeed;
            }
            if (left_blood <= 0 && right_blood <= 0)
            {
                wall.transform.position += fallspeed;
            }
        }
        

        /*
        if (right_blood <= 0 && left_blood<=0)
        {
            wall.transform.position += Vector3.up;
        }*/
        r_cost_big = false;
        l_cost_big = false;
        r_cost = false;
        l_cost = false;
    }
}
