/*
 * Author:  Rick
 * Create:  2017/12/27 15:22:07
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ObjectPool
/// </summary>
public class ObjectPool
{
    private static Dictionary<string, Queue<GameObject>> _objects = new Dictionary<string, Queue<GameObject>>();

    public static void Push(GameObject go)
    {
        Push(go.name, go);
    }

    public static void Push(string key, GameObject go)
    {
        go.SetActive(false);
        if (_objects.ContainsKey(key))
        {
            _objects[key].Enqueue(go);
        }
        else
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            queue.Enqueue(go);
            _objects.Add(key, queue);
        }
    }

    public static bool TryPull(string key, out GameObject go)
    {
        if (_objects.ContainsKey(key) && _objects[key].Count > 0)
        {
            go = _objects[key].Dequeue();
            go.SetActive(true);
            return true;
        }
        go = null;
        return false;
    }
}
