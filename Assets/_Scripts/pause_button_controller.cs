using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_button_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick()
    {
        scene_manager.instance.Pause_Scene(true);
    }
}
