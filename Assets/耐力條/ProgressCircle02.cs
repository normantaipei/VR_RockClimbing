using UnityEngine;

using UnityEngine.UI;

public class ProgressCircle02 : MonoBehaviour
{
   
    //獲取進度圓形圖片與精度Text
    public Image progressCircle;
    //設置目標進度與當前進度
    public float Endurance;
    public GameObject fall;
    
    // Use this for initialization
    void Start()
    {
        Endurance = 100.0f;    
    }
    // Update is called once per frame
    void Update()
    {


        //更新填充圓形進度與文本顯示進度
        Endurance = fall.GetComponent<fall02>().left_blood;
        progressCircle.GetComponent<Image>().fillAmount = Endurance / 100;
 

    }

}