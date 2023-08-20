using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Spawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] Towers;
    [SerializeField] private GameObject PlaceableAreaObj;
    public GameObject Current_Tower;

    private void Start()
    {
        PlaceableAreaObj.SetActive(false);
    }

    private void Update()
    {
        Tower_Attack_System Tascomp;
        if (Current_Tower != null)
        {
            PlaceableAreaObj.SetActive(true);
            Current_Tower.transform.position = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            Current_Tower.transform.position = new Vector3(Current_Tower.transform.position.x, Current_Tower.transform.position.y, 0f);
            Tascomp = Current_Tower.GetComponent<Tower_Attack_System>();

            if (Input.GetMouseButtonDown(0) && Current_Tower != null && Tascomp.IsPlaceabal)
            {
                Tascomp.Tower_Radius_Indecator.SetActive(false);
                Tascomp.IsPlaceabal = false;
                Current_Tower = null;
                PlaceableAreaObj.SetActive(false);
            }
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
