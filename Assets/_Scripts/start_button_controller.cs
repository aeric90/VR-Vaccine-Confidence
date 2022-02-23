using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * VR Vaccine Confidence
 * start_button_controller.cs
 *
 * Created By: Eric DeMarbre
 * 
 * Last Update By: Eric DeMarbre
 * Last Update: December 14, 2021
 *
 * This script contains all code associated to the start button object.
 * 
*/

public class start_button_controller : MonoBehaviour
{
    public string button_flag;
    public Material InactiveMaterial;
    public Material InactiveGazeMaterial;
    public Material ActiveMaterial;
    public Material ActiveGazeMaterial;

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
        ui_controller.instance.Start_Program(button_flag);
    }

    public void ChangeStatus(bool status)
    {
        activated = status;
        SetActiveMaterial(status);
        SetGazeMaterial(false);
    }

    private void SetGazeMaterial(bool gazedAt)
    {
        if (!activated)
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
