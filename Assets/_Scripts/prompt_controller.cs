using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prompt_controller : MonoBehaviour
{
    public string button_type;
    public string button_flag;

    private SpriteRenderer button_sprite;

    public Sprite NormalSprite;
    public Sprite GazeSprite;

    // Start is called before the first frame update


    // Start is called before the first frame update
    void Start()
    {
        button_sprite = GetComponent<SpriteRenderer>();
        SetGazeMaterial(false);
    }
    public void OnPointerEnter()
    {
        SetGazeMaterial(true);
    }

    public void OnPointerExit()
    {
        SetGazeMaterial(false);
    }

    public void OnPointerClick()
    {
        if (button_type == "lang") {
            ui_controller.instance.Select_Language(button_flag);
        }
        if (button_type == "begin")
        {
            ui_controller.instance.Select_Begin();
        }
        if (button_type == "cc")
        {
            ui_controller.instance.Select_CC(button_flag);
        }
        if (button_type == "start")
        { 
            ui_controller.instance.Start_Program(); 
        }
        if (button_type == "resume")
        {
            scene_manager.instance.Pause_Scene(false);
        }
        if (button_type == "quit")
        {
            scene_manager.instance.Quit_Process();
        }
        SetGazeMaterial(false);
    }

    public void ChangeStatus(bool status)
    {
        SetGazeMaterial(false);
    }

    private void SetGazeMaterial(bool gazedAt)
    {
        button_sprite.sprite = gazedAt ? GazeSprite : NormalSprite;
    }
}
