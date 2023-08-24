using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Gathering_Node : MonoBehaviour
{
    [SerializeField] private List<Transform> ROutline = null;
    [SerializeField] private List<GameObject> Gatherers = null;
    [SerializeField] private float GatherRadius = 0f;
    [SerializeField] private LayerMask GatherLayer;
    [SerializeField] private float Recource_Collection_Speed;
    private float Recource_Collection_Speed_Temp;
    public int Total_recources_Node = 1000;
    private bool IsAreaActive = false;
    private Building_Spawner building_Spawner = null;

    private void Start()
    {
        Recource_Collection_Speed_Temp = Recource_Collection_Speed;
        Recource_Collection_Speed = 0f;

        building_Spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<Building_Spawner>();

        foreach (Transform obj in this.transform)
        {
            if (obj != null)
            {
                ROutline.Add(obj);
                obj.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Recource_Collection_Speed >= Recource_Collection_Speed_Temp)
        {
            Total_recources_Node -= 1 * Gatherers.Count;
            Recource_Collection_Speed = 0f;
        }
        else
        {
            Recource_Collection_Speed += Time.deltaTime;
        }


        if (building_Spawner.Current_Building != null)
        {
            if (building_Spawner.Current_Building.CompareTag("Gatherer"))
            {
                for (int i = 0; i < ROutline.Count; i++)
                {
                    ROutline[i].gameObject.SetActive(true);
                }
                IsAreaActive = true;
            }
        }
        else if (IsAreaActive)
        {
            for (int i = 0; i < ROutline.Count; i++)
            {
                ROutline[i].gameObject.SetActive(false);
            }
            IsAreaActive = false;
        }
    }

    private void FixedUpdate()
    {
        Collider2D[] Gobjs = null;
        Gobjs = Physics2D.OverlapCircleAll(this.transform.position, GatherRadius, GatherLayer);
        foreach (Collider2D obj in Gobjs)
        {
            if (obj.gameObject.GetComponent<Resource_Gaterer>().IsPlacedDown && obj.gameObject.GetComponent<Resource_Gaterer>().IsGathering == false)
            {
                Gatherers.Add(obj.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, GatherRadius);
    }
}
