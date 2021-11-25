using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_controller : MonoBehaviour
{
    int x = 2;
    int p = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.gameObject.transform.position.x) >= 1.9f)
        {
            x *= -1;
            p++;
        }

        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), 0.005f);

        if (p >= 10) Destroy(this.gameObject);
    }
}
