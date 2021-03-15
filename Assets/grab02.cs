using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;


public class grab02 : MonoBehaviour
{
    public float left_blood = 100, right_blood = 100;
    public GameObject rightHand;   //右手手把
    public GameObject leftHand;   //右手手把
    //public GameObject stone;       //岩石支點
    public GameObject wall;        //岩壁
    public GameObject playerhead;  //vive頭盔
    public GameObject playerhand;  //vive手把

    private Vector3 pos;           //支點與岩壁相對位置

    private Transform rightPos;    //右手位置
    private Transform leftPos;    //左手位置
    private Transform stonePos;    //支點位置

    public bool gamestart;         //遊戲開始判定
    public bool r_nottired, l_nottired;  //左右手死亡判定

    public bool rightHandGrip, leftHandGrip;//左右手抓取判定

    public bool grabsomething; //是否有抓到石頭
    // Start is called before the first frame update
    void Start()
    {
        rightPos = rightHand.transform;
        leftPos = leftHand.transform;
        stonePos = this.transform;
        pos = wall.transform.position - this.transform.position;
        gamestart = false;
        //雙手血量
        r_nottired = true;
        l_nottired = true;
        rightHandGrip = false;
        leftHandGrip = false;

        grabsomething = false;


    }

    // Update is called once per frame
    void Update()
    {

      
        //抓取判斷
        if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Grip))
        {
            rightHandGrip = true;
            Debug.Log("00000");

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
        if (rightHandGrip && right_blood >= 0)
        {
            right_blood = right_blood - 0.1f;
            gamestart = true;
            //支點與手距離判定
            if (Vector3.Distance(rightPos.position, stonePos.position)<=0.2f)
            {
                this.transform.position = rightPos.position;
                
                grabsomething = true;
            }
            else
            {
                grabsomething = false;
            }
            //右手血量判定
            if (right_blood<=0)
            {
                r_nottired = false;
            }

        }
        else if (!rightHandGrip && right_blood <= 100)
        {
            right_blood = right_blood +0.03f;
        }


        //左手

        if (leftHandGrip && left_blood>=0)
        {

            left_blood = left_blood - 0.1f;
            gamestart = true;
            //支點與手距離判定
            if (Vector3.Distance(leftPos.position, stonePos.position) <= 0.2f)
            {
                this.transform.position = leftPos.position;
                //wall.transform.position = this.transform.position + pos;
                grabsomething = true;
            }
            else
            {
                grabsomething = false;
            }
            //左手血量判定
            if (left_blood <= 0)
            {
                l_nottired = false;
            }
        }
        else if (!leftHandGrip && left_blood <= 100)
        {
            left_blood = left_blood + 0.03f;
        }
        //固定相對位置
        wall.transform.position = this.transform.position + pos;
        this.transform.position = wall.transform.position - pos;
        /*
        //雙手有抓，但沒抓到石頭
        if (!grabsomething && gamestart)
        {
            wall.transform.position += Vector3.up;
            this.transform.position += Vector3.up;
        }
        //雙手都沒抓
        if (!leftHandGrip && !rightHandGrip && gamestart)
        {
            wall.transform.position += Vector3.up;
            this.transform.position += Vector3.up;
        }
        //雙手血量歸零
        if (!r_nottired && !r_nottired)
        {
            wall.transform.position += Vector3.up;
            this.transform.position += Vector3.up;
        }
        */

        //Debug.Log(right_blood);
        //Debug.Log(left_blood);
    }

 
}
