using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_controller : MonoBehaviour
{
    public static ui_controller instance;

    public GameObject read_fade_plane;
    public GameObject pause_plane;
    public GameObject lang_UI;
    public GameObject title_UI;
    public GameObject start_UI;
    public GameObject CC_UI;
    public GameObject pause_UI;
    public GameObject logo_1_UI;
    public GameObject logo_2_UI;
    public GameObject EN_credits_1_UI;
    public GameObject EN_credits_2_UI;
    public GameObject EN_credits_3_UI;
    public GameObject FR_credits_1_UI;
    public GameObject FR_credits_2_UI;
    public GameObject FR_credits_3_UI;
    public GameObject Start_Button;
    public GameObject Pause_Button;

    private string lang_flag = "EN";
    private string cc_flag = "off";

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        aim_selector.instance.ToggleTarget(true);
        //EN_Button.GetComponent<toggle_button_controller>().ChangeStatus(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            scene_manager.instance.Lang_Flag = "EN";
            script_controller.instance.Start_Script();
            aim_selector.instance.ToggleTarget(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scene_manager.instance.Lang_Flag = "FR";
            script_controller.instance.Start_Script();
            aim_selector.instance.ToggleTarget(false);
        }
    }

    public void Select_Language(string lang_flag)
    {
        this.lang_flag = lang_flag;
        // Fade Out?
        title_UI.GetComponent<title_ui_controller>().Set_Title_Text(lang_flag);
        lang_UI.SetActive(false);
        title_UI.SetActive(true);
        // Fade In?
    }

    public void Select_Begin()
    {
        // Fade Out?
        CC_UI.GetComponent<cc_ui_controller>().Set_CC_Text(lang_flag);
        title_UI.SetActive(false);
        CC_UI.SetActive(true);
        // Fade In?
    }

    public void Select_CC(string cc_flag)
    {
        this.cc_flag = cc_flag;
        // Fade Out?
        start_UI.GetComponent<start_ui_controller>().Set_Start_Text(lang_flag, cc_flag);
        CC_UI.SetActive(false);
        start_UI.SetActive(true);
        // Fade In?
    }

    public void Select_Pause()
    {
        pause_UI.GetComponent<pause_ui_controller>().Set_Pause_Text(lang_flag, cc_flag);
        pause_UI.SetActive(true);
    }

    public void Hide_Pause()
    {
        pause_UI.SetActive(false);
    }

    public void Change_Start_Text()
    {
        start_UI.GetComponent<start_ui_controller>().Set_Start_Text(lang_flag, cc_flag);
    }

    public void Start_Program()
    {
        scene_manager.instance.Turn_Rear_Fade_Off();
        start_UI.SetActive(false);
        scene_manager.instance.Lang_Flag = lang_flag;
        if (cc_flag == "yes")
        {
            scene_manager.instance.CC_Flag = true;
        } else
        {
            scene_manager.instance.CC_Flag = false;
        }
        // Caption Toggle
        aim_selector.instance.ToggleTarget(false);
        Toggle_Pause();
        scene_manager.instance.Start_Scene();
    }

    public void SetLangFlag(string lang_flag)
    {
        this.lang_flag = lang_flag;
    }
    public void SetCCFlag(string cc_flag)
    {
        this.cc_flag = cc_flag;
        if (cc_flag == "yes")
        {
            scene_manager.instance.CC_Flag = true;
        }
        else
        {
            scene_manager.instance.CC_Flag = false;
        }
    }

    public void Toggle_Pause_Plane()
    {
        pause_plane.SetActive(!pause_plane.activeSelf);
    }

    public void Toggle_Pause()
    {
        Pause_Button.SetActive(!Pause_Button.activeSelf);
    }

    public void Toggle_Logo_1_UI()
    {
        logo_1_UI.SetActive(!logo_1_UI.activeSelf);
    }

    public void Toggle_Logo_2_UI()
    {
        logo_2_UI.SetActive(!logo_2_UI.activeSelf);
    }

    public void Toggle_EN_Credit_1_UI()
    {
        EN_credits_1_UI.SetActive(!EN_credits_1_UI.activeSelf);
    }

    public void Toggle_EN_Credit_2_UI()
    {
        EN_credits_2_UI.SetActive(!EN_credits_2_UI.activeSelf);
    }

    public void Toggle_EN_Credit_3_UI()
    {
        EN_credits_3_UI.SetActive(!EN_credits_3_UI.activeSelf);
    }

    public void Toggle_FR_Credit_1_UI()
    {
        FR_credits_1_UI.SetActive(!FR_credits_1_UI.activeSelf);
    }

    public void Toggle_FR_Credit_2_UI()
    {
        FR_credits_2_UI.SetActive(!FR_credits_2_UI.activeSelf);
    }

    public void Toggle_FR_Credit_3_UI()
    {
        FR_credits_3_UI.SetActive(!FR_credits_3_UI.activeSelf);
    }

    public void Show_Language_UI()
    {
        lang_UI.SetActive(true);
    }

    public void UI_Reset()
    {
        lang_UI.SetActive(true);
        logo_2_UI.SetActive(false);
    }
}
