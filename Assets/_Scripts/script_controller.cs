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

    private float time_elapsed = 0.0f; // Will store the time in seconds elapsed during the program.
    private sequence_container sequence = new sequence_container(); // Stores the container for the sequence objects. Needs to exist for the deserialization process.

    // Start is called before the first frame update
    void Start()
    {
        // Import the script XML file and deserialize it into the sequence objects for processing.
        Import_Sequence();
    }

    // Update is called once per frame
    void Update()
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
                    // i.e. Instantiate a prefab, play an audio file, transition to a different environment. Since there is only one action
                    // right now, there is no selection structure.

                    // Load the prefab listed in the sequence object and instantiate it under the Treasure parent.
                    // NOTE - This will be replaced by a call to the SCENE_CONTROLLER object passing the Prefab over to it to properly place it in the scene
                    // NOTE - This will also be included with a location, rotation, and scale value as needed
                    var loaded_resource = Resources.Load("Prefabs/" + i.Prefab);
                    GameObject loaded_object = Instantiate(loaded_resource, GameObject.Find("Treasure").transform) as GameObject; //, scenario_objects.Scenario_Object_Position, scenario_objects.Scenario_Object_Rotation, container.transform) as GameObject;
                    
                    // Set the sequence object to completed.
                    i.Complete_Flag = true;
                }
            }
        }
    }

    // This function takes an external XML file and imports the list of sequence objects into the container that can be processed
    // by the script controller
    public void Import_Sequence()
    {
        XmlSerializer serializer = new XmlSerializer(sequence.GetType());
        var myFileStream = new FileStream(Application.persistentDataPath + "/sequence.xml", FileMode.Open);
        sequence = serializer.Deserialize(myFileStream) as sequence_container;
        myFileStream.Close();
    }

    // This function exports the current list of sequence objects in the container to an external XML file. This is primarily used for 
    // testing and verification.
    public void Export_Sequence()
    {
        XmlSerializer serializer = new XmlSerializer(sequence.GetType());
        TextWriter textWriter = new StreamWriter(Application.persistentDataPath + "/sequence.xml");
        serializer.Serialize(textWriter, sequence);
        textWriter.Close();
    }
}
