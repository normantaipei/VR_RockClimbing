using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeightBar : MonoBehaviour
{
    public GameObject point;
    [SerializeField, Range(0f, 0.24f)]
     float height;
    [SerializeField, Range(0f, 0.24f)]
    float move;
    // Start is called before the first frame update
    public GameObject wall;
    float wall_y;

   
    void Start()
    {
        height = 0;
        //move = -0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        wall_y = wall.transform.position.y;
        move = wall_y / -60;
        //move = 0.1f;
        move = Mathf.Clamp(move, 0, 240);
        height = Mathf.Clamp(move, 0, 240);
       /*
        if (Input.GetKey(KeyCode.Space))
        {
            move += 0.001f;
           
        }*/
        
        height = Mathf.Lerp(height, move, Time.deltaTime* 20);
        point.GetComponent<RectTransform>().anchoredPosition = new Vector2(height *10, 0);        
    }
}
