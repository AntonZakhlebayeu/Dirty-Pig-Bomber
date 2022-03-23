using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixAspectRatio : MonoBehaviour
{
    [SerializeField] private Transform Level;

    void Start()
    {
        if (Camera.main.aspect >= 2.1)
            Level.localScale = new Vector3(1.25f, 1.25f, 1);
        else if (Camera.main.aspect == 2)
            Level.localScale = new Vector3(1.15f, 1.25f, 1);
        else 
            Level.localScale = new Vector3(1f, 1.25f, 1);
    }
}
