using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero_antibody_group_controller : MonoBehaviour
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
        animator.SetInteger("scene_state", scene_manager.instance.Get_Scene_State_ID());
    }
}
