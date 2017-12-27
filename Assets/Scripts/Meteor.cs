/*
 * Author:  Rick
 * Create:  2017/12/26 17:39:31
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 陨石
/// </summary>
public class Meteor : MonoBehaviour
{
    public float m_Speed = 5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * m_Speed * Time.deltaTime);

        Vector3 screen = Camera.main.WorldToScreenPoint(transform.position);
        if (screen.y < 0f)
        {
            ObjectPool.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
 //       GameObject.Destroy(collision.gameObject);
 //       GameObject.Destroy(gameObject);
    }

}
