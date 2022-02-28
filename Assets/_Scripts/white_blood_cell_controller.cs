using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class white_blood_cell_controller : MonoBehaviour
{
    private Animator animator;
    public GameObject anti_body_particles;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("scene_state", scene_manager.instance.Get_Scene_State_ID());

        if (scene_manager.instance.Get_Scene_State_ID() == 18) anti_body_particles.SetActive(true);
        if (scene_manager.instance.Get_Scene_State_ID() == 20) anti_body_particles.GetComponent<ParticleSystem>().Stop();
    }
}