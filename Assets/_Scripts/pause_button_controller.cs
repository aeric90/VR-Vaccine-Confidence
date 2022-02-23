using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_button_controller : MonoBehaviour
{
    private bool isPaused = false;

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
        isPaused = !isPaused;
        scene_manager.instance.Pause_Scene(isPaused);
    }
}
