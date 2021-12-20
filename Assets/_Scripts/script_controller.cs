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
    public sequence_container() {  }

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
    private int event_id; // The ID for the type of event that this is
    private bool complete_flag = false; // Flag to determine if this event has been triggered already or not
    private string prefab; // Name of a saved prefab that will be instantiated when the event triggers
    private int scene_id; // ID of the scene code to transition to. This will be used to control animation transitions
    private int script_line_id;

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
}

[Serializable]
[XmlRoot("script_container")]
public class script_container
{
    // ATTRIBUTES
    private List<script_object> script_objects = new List<script_object>(); // List of sequence objects

    // CONSTRUCTORS
    // Deserialization requires an empty contructor.
    public script_container() { }

    // GET/SET 
    public List<script_object> Script_Objects
    {
        get { return script_objects; }
        set { script_objects = value; }
    }

    public string Get_Script_Line(int script_id)
    {
        string script_text_output = "";

        foreach(script_object script_line in script_objects)
        {
            if (script_line.Script_ID == script_id) script_text_output = script_line.Script_Text;
        }

        return script_text_output;
    }
}

[Serializable]
[XmlRoot("script_object")]
public class script_object
{
    // ATTRIBUTES
    private int script_id;
    private string script_text;

    // CONSTRUCTORS
    // Deserialization requires an empty contructor.
    public script_object() { }

    // GET/SET 
    public int Script_ID
    {
        get { return script_id; }
        set { script_id = value; }
    }

    public string Script_Text
    {
        get { return script_text; }
        set { script_text = value; }
    }
}

// The script controller's primary function is to trigger a list of timed events for program based on the contents of an external XML
// file, using the format described in the object model above. Once the program runtime meets the elapsed time requirments, the relevant
// events will be triggered, making the appropriate function calls to other controllers in the program.

public class script_controller : MonoBehaviour
{
    // Public static instance of the script_controller allows other scripts to access the script_controller as needed
    // This needs to be initiated when the game object wakes.
    public static script_controller instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public TextAsset sequence_file;
    public TextAsset EN_script_file;
    public TextAsset FR_script_file;

    private bool script_active = false; // Only start processing the script when this bool is active.
    private string lang_flag = ""; // Language flag used to select subtitle and audio files.
    private float time_elapsed = 0.0f; // Will store the time in seconds elapsed during the program.
    private sequence_container sequence = new sequence_container(); // Stores the container for the sequence objects. Needs to exist for the deserialization process.
    private script_container script = new script_container();

    public bool Script_Active
    {
        get { return script_active; }
        set { script_active = value; }
    }

    public string Lang_Flag
    {
        get { return lang_flag; }
        set { lang_flag = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Import the script XML file and deserialize it into the sequence objects for processing.
        Import_Sequence();
    }

    // Update is called once per frame
    void Update()
    {
        if (Script_Active)
        {
            // Update the program time elapsed.
            time_elapsed += Time.deltaTime;

            // Loop through all the sequence objects in the sequence container
            foreach (sequence_object i in sequence.Sequence_Objects)
            {
                // If the sequence object has not yet been completed
                if (i.Complete_Flag == false)
                {
                    // If the time trigger for the sequence object has been met
                    if (time_elapsed >= i.Start_Time)
                    {
                        // At this point the script controller will check the Event Type ID and perform different functions based on the ID
                        // i.e. Instantiate a prefab, play an audio file, transition to a different environment. 

                        switch(i.Event_Id)
                        {
                            case 1:
                                scene_manager.instance.Single_Spawn(i.Prefab);
                                break;
                            case 2:
                                scene_manager.instance.Quad_Spawn(i.Prefab);
                                break;
                            case 3:
                                scene_manager.instance.Set_Scene_State_ID(i.Scene_ID);
                                break;
                            case 4:
                                scene_manager.instance.Camera_Spawn(i.Prefab);
                                break;
                            case 10:
                                scene_manager.instance.Update_Caption_Text(script.Get_Script_Line(i.Script_Line_ID));
                                break;
                            case 15:
                                scene_manager.instance.Play_Audio_File(lang_flag + "_" + i.Script_Line_ID);
                                break;
                            case 20:
                                scene_manager.instance.Clear_All_Spawns();
                                break;
                            case 22:
                                scene_manager.instance.Clear_Single_Spawn();
                                break;
                            case 23:
                                scene_manager.instance.Clear_Camera_Spawn(i.Prefab);
                                break;
                            case 25:
                                scene_manager.instance.Clear_Quad_Spawn();
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
                        }

                        // Set the sequence object to completed.
                        i.Complete_Flag = true;
                    }
                }
            }
        }
    }

    public void Start_Script()
    {
        Import_Script();
        Script_Active = true;
    }

    // This function takes an external XML file and imports the list of sequence objects into the container that can be processed
    // by the script controller
    public void Import_Sequence()
    {
        Debug.Log(sequence_file.text);
        XmlSerializer serializer = new XmlSerializer(sequence.GetType());
        var reader = new System.IO.StringReader(sequence_file.text);
        sequence = serializer.Deserialize(reader) as sequence_container;
        Debug.Log(sequence.Sequence_Objects.Count);
    }

    public void Import_Script()
    {
        XmlSerializer serializer = new XmlSerializer(script.GetType());

        StringReader reader = null;

        if (lang_flag == "EN")
        {
            reader = new System.IO.StringReader(EN_script_file.text);
        } 
        else if (lang_flag == "FR")
        {
            reader = new System.IO.StringReader(FR_script_file.text);
        }

        script = serializer.Deserialize(reader) as script_container;
    }

    // This function exports the current list of sequence objects in the container to an external XML file. This is primarily used for 
    // testing and verification.
    public void Export_Sequence()
    {
        XmlSerializer serializer = new XmlSerializer(sequence.GetType());
        TextWriter textWriter = new StreamWriter("/Assets/sequence.xml");
        serializer.Serialize(textWriter, sequence);
        textWriter.Close();
    }
}
