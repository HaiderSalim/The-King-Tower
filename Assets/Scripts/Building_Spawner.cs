using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Spawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] Towers;
    [SerializeField] private GameObject[] Gatherers;
    [SerializeField] private GameObject PlaceableTowerAreaObj;
    [SerializeField] private float TowerLockOffDistance = 1f;
    public GameObject Current_Building;

    private void Start()
    {
        PlaceableTowerAreaObj.SetActive(false);
    }

    private void Update()
    {
        Tower_Attack_System Tascomp = null;
        Resource_Gaterer RGcomp = null;
        if (Current_Building != null)
        {

            Vector2 MousPos = (Vector2)_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            float MousDis = Vector2.Distance(MousPos, Current_Building.transform.position);
            //Debug.Log(MousDis);

            if (Current_Building.CompareTag("Tower"))
            {
                PlaceableTowerAreaObj.SetActive(true);
                Tascomp = Current_Building.GetComponent<Tower_Attack_System>();

                if (MousDis >= TowerLockOffDistance || Tascomp.IsPlaceabal == false)
                {
                    Current_Building.transform.position = MousPos;
                    Current_Building.transform.position = new Vector3(Current_Building.transform.position.x, Current_Building.transform.position.y, 0f);
                }

                if (Input.GetMouseButtonDown(0) && Current_Building != null && Tascomp.IsPlaceabal)
                {
                    Tascomp.Tower_Radius_Indecator.SetActive(false);
                    Tascomp.IsPlacedDown = true;
                    Current_Building = null;
                    PlaceableTowerAreaObj.SetActive(false);
                }
            }
            else if (Current_Building.CompareTag("Gatherer"))
            {
                RGcomp = Current_Building.GetComponent<Resource_Gaterer>();

                if (MousDis >= TowerLockOffDistance || RGcomp.IsPlaceabal == false)
                {
                    Current_Building.transform.position = MousPos;
                    Current_Building.transform.position = new Vector3(Current_Building.transform.position.x, Current_Building.transform.position.y, 0f);
                }

                if (Input.GetMouseButtonDown(0) && Current_Building != null && RGcomp.IsPlaceabal)
                {
                    RGcomp.IsPlacedDown = true;
                    Current_Building = null;
                }
            }
        }
    }

    public void Spawn_Tower_1()
    {
        Current_Building = Instantiate(Towers[0], _camera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }

    public void Spawn_Tower_2()
    {
        
    }

    public void Spawn_Tower_3()
    {
        
    }

    public void Spawn_Gatherer_1()
    {
        Current_Building = Instantiate(Gatherers[0], _camera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
