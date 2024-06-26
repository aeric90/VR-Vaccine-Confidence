using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell_controller : MonoBehaviour
{
    private Animator animator;
    public Renderer cell_renderer;
    public GameObject covid_particles;
    public GameObject protein_particles;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("scene_state", scene_manager.instance.Get_Scene_State_ID());
        if (scene_manager.instance.Get_Scene_State_ID() == 6) covid_particles.SetActive(true);
        if (scene_manager.instance.Get_Scene_State_ID() == 13) protein_particles.SetActive(true);
        if (scene_manager.instance.Get_Scene_State_ID() == 12) protein_particles.GetComponent<ParticleSystem>().Stop();
    }
}
