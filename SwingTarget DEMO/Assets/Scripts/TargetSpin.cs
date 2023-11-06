using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpin : MonoBehaviour
{
    // Start is called before the first frame update

    public float spinSpeed = 15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
