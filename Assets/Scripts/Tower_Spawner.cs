using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Spawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] Towers;
    [SerializeField] private GameObject PlaceableAreaObj;
    [SerializeField] private float TowerLockOffDistance = 1f;
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
            Tascomp = Current_Tower.GetComponent<Tower_Attack_System>();

            Vector2 MousPos = (Vector2)_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            float MousDis = Vector2.Distance(MousPos, Current_Tower.transform.position);
            Debug.Log(MousDis);

            if (MousDis >= TowerLockOffDistance || Tascomp.IsPlaceabal == false)
            {
                Current_Tower.transform.position = MousPos;
                Current_Tower.transform.position = new Vector3(Current_Tower.transform.position.x, Current_Tower.transform.position.y, 0f);
            }

            if (Input.GetMouseButtonDown(0) && Current_Tower != null && Tascomp.IsPlaceabal)
            {
                Tascomp.Tower_Radius_Indecator.SetActive(false);
                //Tascomp.IsPlaceabal = false;
                Tascomp.IsPlacedDown = true;
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
