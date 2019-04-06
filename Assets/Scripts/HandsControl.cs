using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsControl : MonoBehaviour
{
    private float timeElapsed = 0.0f;
    private bool stunned = false;
    public float stun_duration = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        {
            NormalControl();
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, -120f);
            timeElapsed += Time.deltaTime;
              if (timeElapsed > stun_duration)
              {
                    this.stunned = false;
                    timeElapsed = 0.0f;
              }
            }
        }
    
    public void NormalControl() {
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
    public void Stun() {
        this.stunned = true;
    }
}
