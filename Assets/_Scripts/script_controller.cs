using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
using UnityEngine;

[Serializable]
[XmlRoot("sequence_container")]
public class sequence_container
{
    private List<sequence_object> sequence_objects = new List<sequence_object>();

    public sequence_container() {  }

    public List<sequence_object> Sequence_Objects
    {
        get { return sequence_objects; }
        set { sequence_objects = value; }
    }
}

[Serializable]
[XmlRoot("sequence_object")]
public class sequence_object
{
    private float start_time;
    private int event_id;
    private bool complete_flag = false;
    private string prefab;

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

    public sequence_object() 
    {
        start_time = 0.0f;
        event_id = 0;
        prefab = "";
    }



}

public class script_controller : MonoBehaviour
{
    public static script_controller instance;
    public float time_elapsed = 0.0f;

    public sequence_container sequence = new sequence_container();

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;

        Import_Sequence();
    }

    // Update is called once per frame
    void Update()
    {
        string resource_path;

        time_elapsed += Time.deltaTime;

        foreach (sequence_object i in sequence.Sequence_Objects)
        {
            if (i.Complete_Flag == false)
            {
                if (time_elapsed >= i.Start_Time)
                {
                    resource_path = "Prefabs/" + i.Prefab;
                    var loaded_resource = Resources.Load(resource_path);
                    Debug.Log(loaded_resource);
                    GameObject loaded_object = Instantiate(loaded_resource, GameObject.Find("Treasure").transform) as GameObject; //, scenario_objects.Scenario_Object_Position, scenario_objects.Scenario_Object_Rotation, container.transform) as GameObject;
                    i.Complete_Flag = true;
                }
            }
        }
    }

    public void Import_Sequence()
    {
        XmlSerializer serializer = new XmlSerializer(sequence.GetType());
        var myFileStream = new FileStream(Application.persistentDataPath + "/sequence.xml", FileMode.Open);
        sequence = serializer.Deserialize(myFileStream) as sequence_container;
        myFileStream.Close();
    }

    public void Export_Sequence()
    {
        XmlSerializer serializer = new XmlSerializer(sequence.GetType());
        TextWriter textWriter = new StreamWriter(Application.persistentDataPath + "/sequence.xml");
        serializer.Serialize(textWriter, sequence);
        textWriter.Close();
    }
}
