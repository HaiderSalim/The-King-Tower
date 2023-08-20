using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class WayPoinFollowSystem : MonoBehaviour
{
    public GameObject WaypointPath;
    [SerializeField] private List<Transform> Waypoints;
    [SerializeField] private float Speed = 0;
    [SerializeField]private int WayPointindex = 0;

    private void Start()
    {
        foreach (Transform w in WaypointPath.transform)
        {
            if (w != null)
            {
                Waypoints.Add(w);
            }
        }
    }

    private void Update()
    {
        //Debug.Log(Waypoints.Count);
        MoveToNextWayPoint();
    }

    private void MoveToNextWayPoint()
    {
        int index = Mathf.Clamp(WayPointindex, 0, Waypoints.Count - 1);
        if (Waypoints[index] != null)
        {
            if (WayPointindex < Waypoints.Count)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, Waypoints[WayPointindex].position, Speed * Time.deltaTime);

                if (Waypoints[WayPointindex].position == this.transform.position)
                {
                    WayPointindex++;
                    //Debug.Log(Waypoints.Count);
                    //Debug.Log(WayPointindex);
                }
            }
        }
        else
        {
            WayPointindex++;
        }
    }
}
