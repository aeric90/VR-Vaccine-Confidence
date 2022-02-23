using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_controller : MonoBehaviour
{
    public static ui_controller instance;

    public GameObject lang_UI;
    public GameObject title_UI;
    public GameObject start_UI;
    //public GameObject cc_UI;
    public GameObject Start_Button;
    public GameObject Pause_Button;

    //private string lang_flag = "EN";
    private bool cc_flag = false;

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
            Hide_Start_UI();
            scene_manager.instance.Lang_Flag = "EN";
            script_controller.instance.Start_Script();
            aim_selector.instance.ToggleTarget(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Hide_Start_UI();
            scene_manager.instance.Lang_Flag = "FR";
            script_controller.instance.Start_Script();
            aim_selector.instance.ToggleTarget(false);
        }
    }

    public void Hide_Start_UI()
    {
        start_UI.SetActive(false);
    }

    public void Set_Flags(string flag)
    {
        //if (flag == "EN") lang_flag = "EN";
        //if (flag == "FR") lang_flag = "FR";
        if (flag == "CC") cc_flag = !cc_flag;
    }

    public void Select_Language(string lang_flag)
    { 
        // Store language flag
        // Fade Out?
        // Hide the language UI
        // Show the Title UI
        // Fade In?
    }



    public void Start_Program(string lang_flag)
    {
        Hide_Start_UI();
        scene_manager.instance.Lang_Flag = lang_flag;
        scene_manager.instance.CC_Flag = true;
        // Caption Toggle
        aim_selector.instance.ToggleTarget(false);
        Toggle_Pause();
        scene_manager.instance.Start_Scene();
    }

    public void Toggle_Pause()
    {
        Pause_Button.SetActive(!Pause_Button.activeSelf);
    }
}
