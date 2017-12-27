/*
 * Author:  Rick
 * Create:  2017/12/26 16:03:34
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家主角类
/// </summary>
public class Player : Airplane
{
    public SpriteRenderer m_Renderer;

    private bool _keyLeft = false;
    private bool _keyUp = false;
    private bool _keyRight = false;
    private bool _keyDown = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        #region 方向按下
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _keyLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _keyUp = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _keyRight = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _keyDown = true;
        }
        #endregion

        #region 方向抬起
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _keyLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            _keyUp = false;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _keyRight = false;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            _keyDown = false;
        }
        #endregion

        #region 实现移动
        Vector3 pos = transform.position;
        if (_keyLeft)
        {
            pos.x -= m_Speed * Time.deltaTime;
            m_Renderer.sprite = Resources.Load<Sprite>("Sprites/playerLeft");
        }
        else if (_keyRight)
        {
            pos.x += m_Speed * Time.deltaTime;
            m_Renderer.sprite = Resources.Load<Sprite>("Sprites/playerRight");
        }
        else
        {
            m_Renderer.sprite = Resources.Load<Sprite>("Sprites/player");
        }

        if (_keyUp)
        {
            pos.y += m_Speed * Time.deltaTime;
        }
        else if (_keyDown)
        {
            pos.y -= m_Speed * Time.deltaTime;
        }
        else
        {

        }

        Vector2 screen = Camera.main.WorldToScreenPoint(pos);
        if (screen.x < Main.screenArea.x || screen.x > Main.screenArea.width)
            pos.x = transform.position.x;

        if (screen.y < Main.screenArea.y || screen.y > Main.screenArea.height)
            pos.y = transform.position.y;

        transform.position = pos;

        //if (_moveArea.Contains(screen))
        //    transform.position = pos;
        #endregion

        #region 实现射击
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EmitLaser(transform.position + Vector3.up * 0.5f);
        }
        #endregion
    }
}
