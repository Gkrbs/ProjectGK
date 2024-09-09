using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensSetting : MonoBehaviour
{
    public static SensSetting instance;
    // 카메라 rotspeed
    public float xRotSpeed = 3;
    public float yRotSpeed = 3;
    //public playerCamInfo cam // 플레이어 카메라 회전 속도 변경용

    public Slider xAxisSlider;
    public Slider yAxisSlider;

    public TMP_Text xAxisValue;
    public TMP_Text yAxisValue;

    [SerializeField] float defaultXAxis;
    [SerializeField] float defaultYAxis;

    public bool isMouseReversal = false;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (PlayerPrefs.HasKey("XSpeed"))
        {
            LoadValue();
        }
        else
        {
            SetXAxisSpeed();
            SetYAxisSpeed();
            //if (cam != null)
            //{
            //}
        }
    }
    public void SetXAxisSpeed()
    {
        float value = xAxisSlider.value;
        xRotSpeed = value;
        xAxisValue.text = value.ToString("F0");// (Mathf.Floor(value * 100f) / 100f).ToString("F2");
        //if (cam != null)
        //    cam.xSpeed = defaultXAxis * value;
        PlayerPrefs.SetFloat("XSpeed", value);
    }
    public void SetYAxisSpeed()
    {
        float value = yAxisSlider.value;
        yRotSpeed = value;
        yAxisValue.text = value.ToString("F0");//(Mathf.Floor(value * 100f) / 100f).ToString("F2");
        //if (cam != null)
        //    cam.ySpeed = defaultYAxis * value;
        PlayerPrefs.SetFloat("YSpeed", value);
    }

    public void SetMouseReversal(bool isOn)
    {
        isMouseReversal = isOn;
    }

    private void LoadValue()
    {
        xAxisSlider.value = xRotSpeed = PlayerPrefs.GetFloat("XSpeed");
        yAxisSlider.value = yRotSpeed = PlayerPrefs.GetFloat("YSpeed");
    }
}
