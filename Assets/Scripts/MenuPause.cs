﻿using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour {

    private PlayerManager m_playerManager;
    private int m_maxPlayers = -1;

    bool m_paused = false;

	// Use this for initialization
	void Start () 
    {
        m_playerManager = GameObject.Find("PlayersManager").GetComponent<PlayerManager>();
        if (!m_playerManager)
        {
            Debug.Log("Can't get PlayerManager in MenuPause");
        }

        m_maxPlayers = m_playerManager.GetMaxPlayer();// = 2 for the moment
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int i = 0; i < m_maxPlayers; ++i)
        {
            if (Input.GetButtonDown("P" + (i + 1).ToString() + " Start") && m_playerManager.GetPlayerTab()[i])
            {
                m_paused = !m_paused;
            }

            if(m_paused && Input.GetButtonUp("P" + (i + 1).ToString() + " A") && m_playerManager.GetPlayerTab()[i])
            {
                m_paused = !m_paused;
            }

            if (m_paused && Input.GetButtonUp("P" + (i + 1).ToString() + " B") && m_playerManager.GetPlayerTab()[i])
            {
                m_paused = !m_paused;
                m_playerManager.ResetToMenu();
                Application.LoadLevel("Menu");
                
            }
        }

        if (m_paused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

	}

    void OnGUI()
    {
         if (m_paused)
         {
             GUI.Box(new Rect(Screen.width / 2.0f - 200.0f / 2.0f, Screen.height/2.0f - 100.0f/2.0f, 200, 100), "Press A to Continue\nPress B to Quit");
         }
    }

    void OnDestroy()
    {
        Time.timeScale = 1.0f;//Check Up on destroy
    }




}
