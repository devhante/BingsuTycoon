using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    private void Awake()
    {
        int width = (Screen.width * 1080) / Screen.height;
        Screen.SetResolution(width, 1080, true);
    }
}
