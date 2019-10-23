using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float gravity;
    private float planetRadius;

    public float PlanetRadius { get => planetRadius; set => planetRadius = value; }

    void Awake()
    {
        planetRadius = this.GetComponent<Renderer>().bounds.extents.magnitude;
    }
}
