using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{

    public GameObject[] stone = new GameObject[20];
    public bool[] r_grabsomething = new bool[20];
    public bool[] l_grabsomething = new bool[20];
    public float left_blood = 100, right_blood = 100;
    public bool r_cost,l_cost;
    public bool gamestart;
    public bool r_grab;

    public GameObject wall;        //岩壁
    // Start is called before the first frame update
    void Start()
    {
        gamestart = false;
        r_grab = false;
    }

    // Update is called once per frame
    void Update()
    {
        gamestart = stone[0].GetComponent<grab>().gamestart;
        Debug.Log(r_grab);
        for (int i = 0; i < 12; i++)
        {
            r_grabsomething[i] = stone[i].GetComponent<grab>().rightHandGrip;
            l_grabsomething[i] = stone[i].GetComponent<grab>().leftHandGrip;
            //bloodCost(r_grabsomething[i]);
            // r_cost = r_cost + r_grabsomething[i];
            

            if (r_grabsomething[i])
            {
                r_cost = true;
            }

            if (l_grabsomething[i])
            {
                l_cost = true;
            }
        }
        if (r_cost) 
        {
            right_blood = right_blood - 0.1f;
        }
        else if(right_blood<=100)
        {
            right_blood = right_blood + 0.3f;
        }
        if (l_cost)
        {
            left_blood = left_blood - 0.1f;
        }
        else if(left_blood<=100)
        {
            left_blood = left_blood + 0.3f;
        }
        // Debug.Log(right_blood);
        if (!r_cost && !l_cost&&gamestart)
        {
            wall.transform.position += Vector3.up;
        }
        if (right_blood <= 0 && left_blood<=0)
        {
            wall.transform.position += Vector3.up;
        }

        r_cost = false;
        l_cost = false;
    }
}
