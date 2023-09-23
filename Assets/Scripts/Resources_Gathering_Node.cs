using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Gathering_Node : MonoBehaviour
{
    [Header("Node Information")]
    [SerializeField] private List<Transform> ROutline = null;
    [SerializeField] private List<GameObject> Gatherers = null;
    [SerializeField] private float GatherRadius = 0f;
    [SerializeField] private LayerMask GatherLayer;
    [SerializeField] private float Recource_Collection_Speed;
    [SerializeField] private General_Global_variables_and_Mathords Global = null;
    private Wave_Manager waveManager = null;
    private float Recource_Collection_Speed_Temp;
    public int Total_recources_Node = 1000;
    private bool IsAreaActive = false;
    private Building_Spawner building_Spawner = null;
    private int WaveMoneyTemp = 0;

    private void Start()
    {
        Recource_Collection_Speed_Temp = Recource_Collection_Speed;
        Recource_Collection_Speed = 0f;

        building_Spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<Building_Spawner>();
        Global= GameObject.FindGameObjectWithTag("GameController").GetComponent<General_Global_variables_and_Mathords>();
        waveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Wave_Manager>();

        //Here I am finding all the child transform of the resource node so, I can easly perform operations on them in runtime.
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
        //Here Resources are reduced depending opon how many gatherer are currently placed on the node.
        if (Recource_Collection_Speed >= Recource_Collection_Speed_Temp && waveManager.isSpawned)
        {
            Total_recources_Node -= 1 * Gatherers.Count;
            WaveMoneyTemp += 1 * Gatherers.Count;
            Recource_Collection_Speed = 0f;
        }
        else
        {
            Recource_Collection_Speed += Time.deltaTime;
        }

        Global.MoneyAnimationPlayerAndMoneyUpdater(!waveManager.isSpawned, WaveMoneyTemp);

        //This Enabels the Resource gatherer placeable area.
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
        //This Disabels the Resource gatherer placeable area.
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
        //Here a virtual circule is mad around the resource node and checked if any resource gatherers a placed on the node if yes they are added to the 
        //gatherers list.
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
        //Because the circule are invisable to repesent them in the editor a circule gizmo is made. 
        Gizmos.DrawWireSphere(this.transform.position, GatherRadius);
    }
}
