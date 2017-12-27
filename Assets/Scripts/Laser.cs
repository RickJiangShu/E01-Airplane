/*
 * Author:  Rick
 * Create:  2017/12/26 17:20:46
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 激光
/// </summary>
public class Laser : MonoBehaviour
{
    private static Queue<GameObject> _pool = new Queue<GameObject>();

    public SpriteRenderer m_Renderer;
    public float m_Speed = 15f;

    private bool _exploding = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_exploding)
            return;

        transform.position = transform.position + transform.up * m_Speed * Time.deltaTime;

        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        if (!Main.screenArea.Contains(screen))
        {
            gameObject.SetActive(false);
            _pool.Enqueue(gameObject);

            //GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case Tags.Meteor:

                break;
        }
        
    }

    private void Explode()
    {
        _exploding = true;

        
    }

    public static GameObject Generate()
    {
        GameObject laser;
        if (_pool.Count > 0)
        {
            laser = _pool.Dequeue();
            laser.SetActive(true);
            return laser;
        }

        GameObject prefab = Resources.Load<GameObject>("Prefabs/PlayerLaser");
        laser = GameObject.Instantiate(prefab);
        return laser;
    }
}
