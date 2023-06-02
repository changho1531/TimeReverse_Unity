using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HA_brigde : MonoBehaviour
{
    public GameObject bridge;
    public GameObject bridge_repair;
    public bool bridge_bool;

    private EdgeCollider2D bridgeColider;

    void Start()
    {
        bridge_repair.SetActive(false);
        bridgeColider = bridge_repair.GetComponent<EdgeCollider2D>();
        bridgeColider.enabled = false;
    }

    void Update()
    {
        if(bridge_bool)
        {
            bridge.SetActive(false);
            bridge_repair.SetActive(true);
            Invoke("Colider", 1.5f);
        }
    }

    public void Colider()
    {
        bridgeColider.enabled = true;
    }
}
