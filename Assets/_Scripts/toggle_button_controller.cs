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
    public Material InactiveMaterial;
    public Material InactiveGazeMaterial;
    public Material ActiveMaterial;
    public Material ActiveGazeMaterial;

    public toggle_button_controller paired_control;

    public string value;

    private bool activated = false;
    private Renderer _myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetGazeMaterial(false);
    }

    // Update is called once per frame
    void Update()
    {

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
        ChangeStatus(!activated);

        if (paired_control != null) paired_control.ChangeStatus(!activated);
    }

    public void ChangeStatus(bool status)
    {
        activated = status;
        SetActiveMaterial(status);
        SetGazeMaterial(false);
        if (status) ui_controller.instance.Set_Flags(value);
    }

    private void SetGazeMaterial(bool gazedAt)
    {
        if(!activated)
        {
            _myRenderer.material = gazedAt ? InactiveGazeMaterial : InactiveMaterial;
        }
        else 
        {
            _myRenderer.material = gazedAt ? ActiveGazeMaterial : ActiveMaterial;
        }
    }

    private void SetActiveMaterial(bool gazedAt)
    {
        _myRenderer.material = gazedAt ? ActiveMaterial : InactiveMaterial;
    }
}