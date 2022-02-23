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

    public TextAsset EN_script_file;
    public TextAsset FR_script_file;

    private script_container script = new script_container();

    public void Start_Script()
    {
        Import_Script();
    }


    public void Import_Script()
    {
        XmlSerializer serializer = new XmlSerializer(script.GetType());

        StringReader reader = null;

        if (scene_manager.instance.Lang_Flag == "EN")
        {
            reader = new System.IO.StringReader(EN_script_file.text);
        } 
        else if (scene_manager.instance.Lang_Flag == "FR")
        {
            reader = new System.IO.StringReader(FR_script_file.text);
        }

        script = serializer.Deserialize(reader) as script_container;
    }

    public string Get_Script_Line(int script_line_id)
    {
        return script.Get_Script_Line(script_line_id);
    }
}
