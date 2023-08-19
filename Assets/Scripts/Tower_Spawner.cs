using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Spawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] Towers;
    public GameObject Current_Tower;

    private void Update()
    {
        if (Current_Tower != null)
        {
            Current_Tower.transform.position = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            Current_Tower.transform.position = new Vector3(Current_Tower.transform.position.x, Current_Tower.transform.position.y, 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Current_Tower = null;
        }
    }

    public void Spawn_Tower_1()
    {
        Current_Tower = Instantiate(Towers[0], _camera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }

    public void Spawn_Tower_2()
    {
        
    }

    public void Spawn_Tower_3()
    {
        
    }

}
