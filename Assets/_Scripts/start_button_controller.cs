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
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public string flag;

    private Renderer _myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    public void OnPointerClick()
    {
        start_ui_controller.instance.Hide_UI();
        script_controller.instance.Lang_Flag = flag;
        script_controller.instance.Start_Script();
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
