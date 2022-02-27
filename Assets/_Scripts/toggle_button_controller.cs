using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * VR Vaccine Confidence
 * toggle_button_controller.cs
 *
 * Created By: Eric DeMarbre
 * 
 * Last Update By: Eric DeMarbre
 * Last Update: Jan 15, 2022
 *
 * This script contains all code associated to the start button object.
 * 
*/

public class toggle_button_controller : MonoBehaviour
{
    public Sprite InactiveMaterial;
    public Sprite InactiveGazeMaterial;
    public Sprite ActiveMaterial;
    public Sprite ActiveGazeMaterial;

    public toggle_button_controller paired_control;

    public string button_type;
    public string button_flag;

    private bool activated = false;
    private SpriteRenderer _myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter()
    {

    }

    public void OnPointerExit()
    {

    }

    public void OnPointerClick()
    {
        ChangeStatus(!activated);

        if (button_type == "lang")
        {
            ui_controller.instance.SetLangFlag(button_flag);
        }
        if (button_type == "cc")
        {
            ui_controller.instance.SetCCFlag(button_flag);
        }

        if (paired_control != null) paired_control.ChangeStatus(!activated);
        ui_controller.instance.Change_Start_Text();
    }

    public void ChangeStatus(bool status)
    {
        activated = status;
        SetActiveMaterial(status);
        SetGazeMaterial(false);
    }

    private void SetGazeMaterial(bool gazedAt)
    {
        if(!activated)
        {
            _myRenderer.sprite = gazedAt ? InactiveGazeMaterial : InactiveMaterial;
        }
        else 
        {
            _myRenderer.sprite = gazedAt ? ActiveGazeMaterial : ActiveMaterial;
        }
    }

    private void SetActiveMaterial(bool gazedAt)
    {
        _myRenderer.sprite = gazedAt ? ActiveMaterial : InactiveMaterial;
    }

    public bool GetActiveStatus()
    {
        return _myRenderer.sprite == ActiveMaterial;
    }
}