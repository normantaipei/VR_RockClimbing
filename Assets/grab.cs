using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;


public class grab : MonoBehaviour
{
    public float left_blood = 100, right_blood = 100;
    public GameObject fall;
    //public bool r_cost, l_cost;

    public GameObject rightHand;   //右手手把
    public GameObject leftHand;   //右手手把
    //public GameObject stone;       //岩石支點
    public GameObject wall;        //岩壁

    private Vector3 pos;           //支點與岩壁相對位置

    private Transform rightPos;    //右手位置
    private Transform leftPos;    //左手位置
    private Transform stonePos;    //支點位置

    public bool gamestart;         //遊戲開始判定
    public bool r_nottired, l_nottired;  //左右手死亡判定

    public bool rightHandGrip, leftHandGrip;//左右手抓取判定

    public bool grabsomething; //是否有抓到石頭

    fall02 mainfall02;
    // Start is called before the first frame update
        
    void Start()
    {
        rightPos = rightHand.transform;
        leftPos = leftHand.transform;
        stonePos = this.transform;
        pos = wall.transform.position - this.transform.position;
        gamestart = false;
        mainfall02 = fall.GetComponent<fall02>();
        //雙手血量

        //r_nottired = true;
        //l_nottired = true;
        rightHandGrip = false;
        leftHandGrip = false;

        grabsomething = false;


    }

    // Update is called once per frame
    void Update()
    {
        right_blood = mainfall02.right_blood;
        left_blood = mainfall02.left_blood;

        //抓取判斷
        if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Grip))
        {
            rightHandGrip = true;
        }
        else
        {
            rightHandGrip = false;
            
        }

        if (ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Grip))
        {
            leftHandGrip = true;
            
        }
        else
        {
            leftHandGrip = false;
            
        }

        //右手
        //血量判斷
        if (rightHandGrip && right_blood >= 0&& Vector3.Distance(rightPos.position, stonePos.position) <= 0.2f)
        {
            //right_blood = right_blood - 0.1f;
            gamestart = true;
            this.transform.position = rightPos.position;
            wall.transform.position = this.transform.position + pos;
            grabsomething = true;
            mainfall02.r_cost = true;
           // mainfall02.gamestart = true;
            //支點與手距離判定
            /*
            if (Vector3.Distance(rightPos.position, stonePos.position)<=0.2f)
            {
                this.transform.position = rightPos.position;
                wall.transform.position = this.transform.position + pos;
                //grabsomething = true;
                fall.GetComponent<fall02>().r_cost = true;
            }
            else
            {
                //grabsomething = false;
                fall.GetComponent<fall02>().r_cost = false;

            }*/

        }
        else
        {
            //mainfall02.r_cost = false;
            grabsomething = false;
            this.transform.position = wall.transform.position - pos;
            //right_blood = right_blood +0.03f;
        }


        //左手

        if (leftHandGrip && left_blood>=0&& Vector3.Distance(leftPos.position, stonePos.position) <= 0.2f)
        {

            //left_blood = left_blood - 0.1f;
            gamestart = true;
            //支點與手距離判定
            this.transform.position = leftPos.position;
            wall.transform.position = this.transform.position + pos;
            //grabsomething = true;
            mainfall02.l_cost = true;
            /*
            if (Vector3.Distance(leftPos.position, stonePos.position) <= 0.2f)
            {
                this.transform.position = leftPos.position;
                wall.transform.position = this.transform.position + pos;
                //grabsomething = true;
                mainfall02.l_cost = true;
            }
            else
            {
                //grabsomething = false;
                fall.GetComponent<fall02>().l_cost = false;
                this.transform.position = wall.transform.position - pos;
            }*/
        }
        else
        {
            //fall.GetComponent<fall02>().l_cost = false;
            this.transform.position = wall.transform.position - pos;
        }
        //固定相對位置
        
    }

 
}
