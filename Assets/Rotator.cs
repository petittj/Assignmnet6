using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float SlideCube;
    private void Update()
    {


        SlideCube = 20;
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime*SlideCube);
    }
}
