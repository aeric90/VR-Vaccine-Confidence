using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_manager : MonoBehaviour
{
    public static scene_manager instance;

    public GameObject single_spawn;
    public GameObject[] quad_spawns;

    public Material office_mat;
    public Material blood_stream_mat;

    private int scene_state = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear_All_Spawns()
    {
        Clear_Single_Spawn();
        Clear_Quad_Spawn();
    }

    public void Set_Scene_State_ID(int i)
    {
        scene_state = i;
    }

    public void Skybox_To_Office()
    {
        RenderSettings.skybox = office_mat;
    }

    public void Skybox_To_Blood()
    {
        RenderSettings.skybox = blood_stream_mat;
    }

    public void Single_Spawn(string prefab_name)
    {
        var loaded_resource = Resources.Load("Prefabs/" + prefab_name);

        GameObject loaded_object = Instantiate(loaded_resource, single_spawn.transform) as GameObject;
    }

    public void Clear_Single_Spawn()
    {
        foreach(Transform child in single_spawn.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Quad_Spawn(string prefab_name)
    {
        var loaded_resource = Resources.Load("Prefabs/" + prefab_name);

        foreach (GameObject spawn in quad_spawns)
        {
            GameObject loaded_object = Instantiate(loaded_resource, spawn.transform) as GameObject;
        }
    }

    public void Clear_Quad_Spawn()
    {
        foreach(GameObject spawn in quad_spawns)
        {
            foreach (Transform child in spawn.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
