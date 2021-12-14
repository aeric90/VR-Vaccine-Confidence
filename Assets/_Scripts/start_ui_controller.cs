using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_ui_controller : MonoBehaviour
{
    public static start_ui_controller instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Hide_UI();
            script_controller.instance.LangFlag = "EN";
            script_controller.instance.ScriptActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Hide_UI();
            script_controller.instance.LangFlag = "FR";
            script_controller.instance.ScriptActive = true;
        }
    }

    public void Hide_UI()
    {
        this.gameObject.SetActive(false);
    }
}