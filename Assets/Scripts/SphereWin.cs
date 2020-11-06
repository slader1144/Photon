using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;


public class SphereWin : MonoBehaviour
{
    private PhotonTransformView esfera;
    public float velocidad;
    private int i=0;
    private Character player;
    // Start is called before the first frame update
    void Start()
    {
        esfera = GetComponent<PhotonTransformView>();
        player = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update() {

        if (this.i == 1)
        {

            esfera.transform.position += (-transform.right) * Time.deltaTime * velocidad;

        }
        else {

            esfera.transform.position += (transform.right) * Time.deltaTime * velocidad;

        }

        
    }
            

    private void OnTriggerEnter(Collider other) {
        
        if (this.i == 1)
        {

            this.i = 0;
        }
        else {
            this.i = 1;
        }

        Debug.Log("Hit");

    }
}
