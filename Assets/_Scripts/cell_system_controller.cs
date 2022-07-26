using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell_system_controller : MonoBehaviour
{
    private Animator animator;
    public GameObject covid_cell_container;
    public GameObject cell_snap;
    private bool swap = false;

    private float time_elapsed;
    private float lerp_duration = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int scene_state = scene_manager.instance.Get_Scene_State_ID();
        
        animator.SetInteger("scene_state", scene_state);

        if (scene_state == 4)
        {
            Vector3 target = Vector3.Lerp(covid_cell_container.transform.position, cell_snap.transform.position, time_elapsed / lerp_duration);
            time_elapsed += Time.deltaTime;
            covid_cell_container.transform.position = target;
        }

        if(scene_state == 5)
        {
            if (swap == false)
            {
                covid_cell_container.transform.SetParent(cell_snap.transform, true);
                swap = true;
            }
        }
    }
}
