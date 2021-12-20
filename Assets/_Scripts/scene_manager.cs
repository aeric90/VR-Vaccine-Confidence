using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_manager : MonoBehaviour
{
    public static scene_manager instance;

    public GameObject single_spawn;
    public GameObject[] quad_spawns;
    public GameObject camera_spawn;
    public TMPro.TextMeshProUGUI caption_text;

    public GameObject blood_stream;

    public Material office_mat;
    public Material blood_stream_mat;

    private string caption_buffer = "";
    private int scene_state = 0;
    private bool fade_state = false;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        caption_text.text = caption_buffer;
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

    public int Get_Scene_State_ID()
    {
        return scene_state;
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

    public void Camera_Spawn(string prefab_name)
    {
        var loaded_resource = Resources.Load("Prefabs/" + prefab_name);

        GameObject loaded_object = Instantiate(loaded_resource, camera_spawn.transform) as GameObject;
    }

    public void Clear_Camera_Spawn(string prefab_name)
    {
        foreach (Transform child in camera_spawn.transform)
        {
            if(child.name.Contains(prefab_name)) Destroy(child.gameObject);
        }
    }

    public void Update_Caption_Text(string text)
    {
        caption_buffer = text;
    }

    public void Play_Audio_File(string file_name)
    {
        audioManager.instance.Play(file_name);
    }

    public void Start_Blood_Stream()
    {
        blood_stream.SetActive(true);
    }

    public void Stop_Blood_Stream()
    {
        blood_stream.SetActive(false);
    }

    public bool Get_Fade_State()
    {
        return fade_state;
    }

    public void Turn_Fade_On()
    {
        fade_state = true;
    }

    public void Turn_Fade_Off()
    {
        fade_state = false;
    }
}
