﻿using System.Collections;
using UnityEngine;
[AddComponentMenu("NotSkyrim/NPC/Interact")]
public class Interact : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public GameObject mainCam;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast (interact,out hitInfo, 10))
            {
                #region NPC Dialogue
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Dialogue dlg = hitInfo.transform.GetComponent<Dialogue>();
                    if (dlg != null)
                    { 
                    dlg.showDlg = true;
                    player.GetComponent<CharacterMovement>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Debug.Log("Talking to NPC.");
                    }
                }
                #endregion
                #region Chest
                if (hitInfo.collider.CompareTag("Chest"))
                {
                    Debug.Log("Opening chest.");
                }
                #endregion 
                #region Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Picking up item.");
                }
                #endregion
            }
        }
    }
}
