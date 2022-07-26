using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera360 : MonoBehaviour
{
    public Camera _camera;

    public RenderTexture _eyeCubemap;
    public RenderTexture _equirectTexture;

    private int frame_id = 0;

    // Start is called before the first frame update
    void Start()
    {
        _camera.stereoSeparation = 0.064f; // 64mm
    }

    void Update()
    {   
        RecordFrame(frame_id);
        frame_id++;
    }

    public void RecordFrame(int frame_id)
    {
        var eC = new RenderTexture(_eyeCubemap);
        var rT = new RenderTexture(_equirectTexture);

        _camera.RenderToCubemap(eC, 63, Camera.MonoOrStereoscopicEye.Left);
        eC.ConvertToEquirect(rT, Camera.MonoOrStereoscopicEye.Left);
        _camera.RenderToCubemap(eC, 63, Camera.MonoOrStereoscopicEye.Right);
        eC.ConvertToEquirect(rT, Camera.MonoOrStereoscopicEye.Right);

        // Creates buffer
        Texture2D tempTexture = new Texture2D(rT.width, rT.height);
        tempTexture.hideFlags = HideFlags.HideAndDontSave; //added to avoid memory leak
        tempTexture.ReadPixels(new Rect(0, 0, rT.width, rT.height), 0, 0);
        // Exports to a PNG
        var bytes = tempTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes("D:/frames/vaccine_frame_" + frame_id + ".png", bytes);

        Destroy(tempTexture); //added to avoid memory leak
        Destroy(eC); //added to avoid memory leak
        Destroy(rT); //added to avoid memory leak
    }
}
