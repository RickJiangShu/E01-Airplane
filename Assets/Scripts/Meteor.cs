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
    public int m_Hp = 1;

    private SpriteRenderer _renderer;
    private Sprite _defaultSprite;
    private bool _exploding = false;
    private int _hp;

    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _renderer.sprite;
        _hp = m_Hp;
    }

    public void OnDisable()
    {
        _hp = m_Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_exploding)
            return;

        transform.Translate(Vector3.down * m_Speed * Time.deltaTime);

        Vector3 screen = Camera.main.WorldToScreenPoint(transform.position);
        if (screen.y < 0f)
        {
            ObjectPool.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.Player)
        {
            Explode();

            Player player = collision.GetComponent<Player>();
            player.Hurt();
        }
 //       GameObject.Destroy(collision.gameObject);
 //       GameObject.Destroy(gameObject);
    }

    private void Explode()
    {
        _exploding = true;

        _renderer.sprite = Resources.Load<Sprite>("Sprites/laserRedShot");
        Invoke("Kill", 0.1f);

        SoundManager.instance.PlayExplode();
    }

    private void Kill()
    {
        if (_exploding)
        {
            _exploding = false;
            _renderer.sprite = _defaultSprite;//恢复
        }
        ObjectPool.Push(gameObject);
    }

    public int hp
    {
        get { return _hp; }
        set
        {
            _hp = value;
            if (_hp <= 0)
            {
                Explode();
            }
        }
    }
}
