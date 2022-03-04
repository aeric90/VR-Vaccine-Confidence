using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
using UnityEngine;

/* 
 * VR Vaccine Confidence
 * script_controller.cs
 *
 * Created By: Eric DeMarbre
 * 
 * Last Update By: Eric DeMarbre
 * Last Update: Novemeber 21st, 2021
 *
 * This script contains all code associated to the script controller object.
 * 
*/

[Serializable]
[XmlRoot("sequence_container")]
// This class contains a list of sequence objects and is required by the deserialization process.
public class sequence_container
{
    // ATTRIBUTES
    private List<sequence_object> sequence_objects = new List<sequence_object>(); // List of sequence objects

    // CONSTRUCTORS
    // Deserialization requires an empty contructor.
    public sequence_container() { }

    // GET/SET 
    public List<sequence_object> Sequence_Objects
    {
        get { return sequence_objects; }
        set { sequence_objects = value; }
    }
}

[Serializable]
[XmlRoot("sequence_object")]
// This class describes the sequence object which is a timed event that the program will perform.
public class sequence_object
{
    // ATTRIBUTES
    private float start_time; // The program's elapsed time in seconds where the event will trigger
    private bool complete_flag = false; // Flag to determine if this event has been triggered already or not
    private int event_id; // The ID for the type of event that this is
    private string prefab; // Name of a saved prefab that will be instantiated when the event triggers
    private int scene_id; // ID of the scene code to transition to. This will be used to control animation transitions
    private int script_line_id;
    private List<sequence_event> sequence_events = new List<sequence_event>(); // List of sequence events

    // CONSTRUCTORS
    // Deserialization requires an empty contructor.
    public sequence_object()
    {
        start_time = 0.0f;
        event_id = 0;
        prefab = "";
    }

    // GET/SET 
    public float Start_Time
    {
        get { return start_time; }
        set { start_time = value; }
    }
    public int Event_Id
    {
        get { return event_id; }
        set { event_id = value; }
    }
    public bool Complete_Flag
    {
        get { return complete_flag; }
        set { complete_flag = value; }
    }
    public string Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }
    public int Scene_ID
    {
        get { return scene_id; }
        set { scene_id = value; }
    }

    public int Script_Line_ID
    {
        get { return script_line_id; }
        set { script_line_id = value; }
    }

    public List<sequence_event> Sequence_Events
    {
        get { return sequence_events; }
        set { sequence_events = value; }
    }
}

[Serializable]
[XmlRoot("sequence_event")]
public class sequence_event
{
    private int event_id; // The ID for the type of event that this is
    private string prefab; // Name of a saved prefab that will be instantiated when the event triggers
    private int scene_id; // ID of the scene code to transition to. This will be used to control animation transitions
    private int script_line_id;

    // CONSTRUCTORS
    // Deserialization requires an empty contructor.
    public sequence_event()
    {
        event_id = 0;
        prefab = "";
        scene_id = 0;
        script_line_id = 0;
    }

    // GET/SET 
    public int Event_Id
    {
        get { return event_id; }
        set { event_id = value; }
    }

    public string Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }
    public int Scene_ID
    {
        get { return scene_id; }
        set { scene_id = value; }
    }

    public int Script_Line_ID
    {
        get { return script_line_id; }
        set { script_line_id = value; }
    }
}

    public class sequence_controller : MonoBehaviour
{
    // Public static instance of the script_controller allows other scripts to access the script_controller as needed
    // This needs to be initiated when the game object wakes.
    public static sequence_controller instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public bool test_sequence;
    public TextAsset sequence_file;

    public TextAsset EN_sequence_file;
    public TextAsset FR_sequence_file;

    private bool sequence_active = false; // Only start processing the script when this bool is active.

    private float time_elapsed = 0.0f; // Will store the time in seconds elapsed during the program.
    private int current_sequence_id = 0;
    private sequence_container sequence = new sequence_container(); // Stores the container for the sequence objects. Needs to exist for the deserialization process.

    public bool Sequence_Active
    {
        get { return sequence_active; }
        set { sequence_active = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Sequence_Active)
        {
            // Update the program time elapsed.
            time_elapsed += Time.deltaTime;

            if (current_sequence_id < sequence.Sequence_Objects.Count)
            {
                sequence_object current_sequence = sequence.Sequence_Objects[current_sequence_id];

                // If the time trigger for the sequence object has been met
                if (time_elapsed >= current_sequence.Start_Time)
                {
                    // At this point the script controller will check the Event Type ID and perform different functions based on the ID
                    // i.e. Instantiate a prefab, play an audio file, transition to a different environment. 

                    foreach (sequence_event e in current_sequence.Sequence_Events)
                    {
                        switch (e.Event_Id)
                        {
                            case 1:
                                scene_manager.instance.Single_Spawn(e.Prefab);
                                break;
                            case 2:
                                scene_manager.instance.Quad_Spawn(e.Prefab);
                                break;
                            case 3:
                                scene_manager.instance.Set_Scene_State_ID(e.Scene_ID);
                                break;
                            case 4:
                                scene_manager.instance.Camera_Spawn(e.Prefab);
                                break;
                            case 10:
                                scene_manager.instance.Play_Script_Line(e.Script_Line_ID);
                                break;
                            /*
                            case 10:
                                scene_manager.instance.Update_Caption_Text(script.Get_Script_Line(current_sequence.Script_Line_ID));
                                break;
                            case 15:
                                scene_manager.instance.Play_Audio_File(lang_flag + "_" + current_sequence.Script_Line_ID);
                                break;
                            */
                            case 20:
                                scene_manager.instance.Clear_All_Spawns();
                                break;
                            case 22:
                                scene_manager.instance.Clear_Single_Spawn();
                                break;
                            case 23:
                                scene_manager.instance.Clear_Camera_Spawn(e.Prefab);
                                break;
                            case 24:
                                scene_manager.instance.Clear_Single_Spawn(e.Prefab);
                                break;
                            case 25:
                                scene_manager.instance.Clear_Quad_Spawn();
                                break;
                            case 26:
                                scene_manager.instance.Clear_Quad_Spawn(e.Prefab);
                                break;
                            case 30:
                                scene_manager.instance.Skybox_To_Office();
                                break;
                            case 35:
                                scene_manager.instance.Skybox_To_Blood();
                                break;
                            case 40:
                                scene_manager.instance.Start_Blood_Stream();
                                break;
                            case 45:
                                scene_manager.instance.Stop_Blood_Stream();
                                break;
                            case 50:
                                scene_manager.instance.Turn_Fade_On();
                                break;
                            case 55:
                                scene_manager.instance.Turn_Fade_Off();
                                break;
                            case 60:
                                music_controller.instance.Play();
                                break;
                            case 65:
                                music_controller.instance.Trigger_Fade();
                                break;
                            case 70:
                                scene_manager.instance.Turn_Rear_Fade_On();
                                break;
                            case 75:
                                scene_manager.instance.Turn_Rear_Fade_Off();
                                break;
                            case 80:
                                ui_controller.instance.Toggle_Logo_UI();
                                break;
                            case 99:
                                scene_manager.instance.End_Scene();
                                break;
                        }
                    }

                    // Set the sequence object to completed.
                    current_sequence.Complete_Flag = true;
                    time_elapsed = 0;
                    current_sequence_id++;
                }
            }
        }
    }

    public void Import_Sequence()
    {
        XmlSerializer serializer = new XmlSerializer(sequence.GetType());
        StringReader reader = null;

        if (test_sequence)
        {
            reader = new System.IO.StringReader(sequence_file.text);
        }
        else
        {
            if (scene_manager.instance.Lang_Flag == "EN")
            {
                reader = new System.IO.StringReader(EN_sequence_file.text);
            }
            else if (scene_manager.instance.Lang_Flag == "FR")
            {
                reader = new System.IO.StringReader(FR_sequence_file.text);
            }
        }

        sequence = serializer.Deserialize(reader) as sequence_container;
    }

    public void End_Sequence()
    {
        sequence_active = false;
        current_sequence_id = 0;
        time_elapsed = 0.0f;
    }
}
