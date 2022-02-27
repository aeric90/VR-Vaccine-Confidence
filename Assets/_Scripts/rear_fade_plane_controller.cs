using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rear_fade_plane_controller : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("rear_fade_switch" , scene_manager.instance.Get_Rear_Fade_State());
    }
}
