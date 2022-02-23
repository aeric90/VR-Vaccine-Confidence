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
            // Call ui_controller lang page selection function
        }
        if (button_type == "start") { ui_controller.instance.Start_Program(button_flag); }
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
