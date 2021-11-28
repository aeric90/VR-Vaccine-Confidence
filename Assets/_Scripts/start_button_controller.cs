using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
