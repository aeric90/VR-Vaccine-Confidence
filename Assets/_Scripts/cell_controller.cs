using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell_controller : MonoBehaviour
{
    public Renderer cell_renderer;

    private float fade_in_duration = 3.0f;
    private float lerp_param = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lerp_param += Time.deltaTime;

        Color cell_color = cell_renderer.material.color;

        if (cell_color.a < 1.0f)
        {
            float a = Mathf.Lerp(0.0f, 1.0f, lerp_param / fade_in_duration);
            cell_color.a = a;
            cell_renderer.material.color = cell_color;
        }
    }
}
