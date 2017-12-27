/*
 * Author:  Rick
 * Create:  2017/12/27 17:09:30
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy
/// </summary>
public class Enemy : Airplane
{
    public float m_LaserInterval = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            EmitLaser(transform.position + Vector3.down * 0.5f);
        }
      //  transform.Translate(Vector3.down * m_Speed * Time.deltaTime);
    }
}
