﻿using UnityEngine;
using System.Collections;

public class CameraMgr : MonoBehaviour
{
	public int m_size = 9;

	public int m_width  = 1024;
	public int m_height = 576;

    private void Awake()
    {
        /*//Get camera component and set ortho size
        Camera camera = GetComponent("Camera") as Camera;
        camera.orthographicSize = LevelMgr.instance.m_levelSize;

        //Set position
		transform.position = new Vector3(LevelMgr.instance.m_levelSize * 16/9, LevelMgr.instance.m_levelSize, -10);*/
		
		//Set resolution
		Screen.SetResolution(m_width, m_height, false);

		//Set ortho size
		camera.orthographicSize = m_size;
		
		//Set position
		transform.position = new Vector3(m_size * 16/9, m_size, -10);
    }
}
