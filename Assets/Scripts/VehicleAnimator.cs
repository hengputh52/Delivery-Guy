using UnityEngine;
using System.Collections.Generic;

public class VehicleAnimator : MonoBehaviour
{
    public float speed = 10f;
    private Transform[] wheels;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.localPosition;
        List<Transform> wheelList = new List<Transform>();
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.name.ToLower().Contains("wheel") || child.name.ToLower().Contains("tire"))
            {
                wheelList.Add(child);
            }
        }
        wheels = wheelList.ToArray();
    }
    
    void Update()
    {
        foreach(var wheel in wheels)
        {
            if(wheel != null)
                wheel.Rotate(Vector3.right * speed * 50 * Time.deltaTime);
        }
        
        float y = Mathf.Sin(Time.time * 15f) * 0.02f;
        transform.localPosition = initialPos + new Vector3(0, y, 0);
    }
}
