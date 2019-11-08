using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform spider;


    // Start is called before the first frame update

    // Update is called once per frame
     void Update()
    {

        transform.LookAt(player);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);

    }
}
