using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HA_dam_2 : MonoBehaviour
{
    public Vector3 targetPosition;
    public GameObject player;

    public bool restart;
    public bool move;

    void Update()
    {
        if(restart)
        {
            SceneManager.LoadScene("HA_stage1");
            restart = false;
        }
        if(move)
        {
            player.transform.position = targetPosition;
            move = false;
        }
    }
}