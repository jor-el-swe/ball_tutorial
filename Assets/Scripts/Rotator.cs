﻿using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10, 45, 30)*Time.deltaTime);
    }
}
