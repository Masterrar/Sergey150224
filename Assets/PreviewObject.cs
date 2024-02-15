using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    [SerializeField] private float rotateAngle = 2.0f;
    void Start()
    {
        this.transform.Rotate(0,rotateAngle,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
