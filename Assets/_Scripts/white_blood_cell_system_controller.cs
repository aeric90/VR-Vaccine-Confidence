using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class white_blood_cell_system_controller : MonoBehaviour
{
    public GameObject spike_1;
    public GameObject spike_2;
    public GameObject spike_3;

    public GameObject spike_1_snap;
    public GameObject spike_2_snap;
    public GameObject spike_3_snap;

    private bool swap_1 = false;
    private bool swap_2 = false;
    private bool swap_3 = false;

    private float time_elapsed;
    private float lerp_duration = 100.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int scene_state = scene_manager.instance.Get_Scene_State_ID();


        if (scene_state == 16)
        {
            Vector3 target = Vector3.Lerp(spike_1.transform.position, spike_1_snap.transform.position, time_elapsed / lerp_duration);
            time_elapsed += Time.deltaTime;
            spike_1.transform.position = target;
        }

        if (scene_state == 17)
        {
            if (swap_1 == false)
            {
                Debug.Log("snap 1");
                spike_1.transform.SetParent(spike_1_snap.transform, true);
                spike_1.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                swap_1 = true;
            }
        }

        if (scene_state == 19)
        {
            Vector3 target = Vector3.Lerp(spike_2.transform.position, spike_2_snap.transform.position, time_elapsed / lerp_duration);
            time_elapsed += Time.deltaTime;
            spike_2.transform.position = target;
        }

        if (scene_state == 20)
        {
            if (swap_2 == false)
            {
                spike_2.transform.SetParent(spike_2_snap.transform, true);
                spike_2.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                swap_2 = true;
            }
        }

        if (scene_state == 22)
        {
            Vector3 target = Vector3.Lerp(spike_3.transform.position, spike_3_snap.transform.position, time_elapsed / lerp_duration);
            time_elapsed += Time.deltaTime;
            spike_3.transform.position = target;
        }

        if (scene_state == 23)
        {
            if (swap_3 == false)
            {
                spike_3.transform.SetParent(spike_3_snap.transform, true);
                spike_3.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                swap_3 = true;
            }
        }
    }
}
