using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float left = Input.GetAxis("Horizontal"); //Dodatnie - lewo, Ujemne - prawo
        float up = Input.GetAxis("Vertical"); //Dodatnie - góra, Ujemne - dół
        if (left > 0.3)
        {
            if (up > 0.5)
                transform.rotation = Quaternion.Euler(0, 0, -55f);
            else if (up < -0.3)
                transform.rotation = Quaternion.Euler(0, 0, -120f);
            else
                transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
        else if (left < -0.3)
        {
            if (up > 0.3)
                transform.rotation = Quaternion.Euler(0, 0, 55f);
            else if (up < -0.3)
                transform.rotation = Quaternion.Euler(0, 0, 120f);
            else
                transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else transform.rotation = Quaternion.Euler(0, 0, -20f);

    }
}
