using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Gaterer : MonoBehaviour
{
    [Header("Gatherer Information")]
    [SerializeField] int GatheringAmount = 1;//amount of gathering done per tick.
    public bool IsPlaceabal = false;
    public bool IsPlacedDown = false;

    public bool IsGathering = false;
    //If we consider gathering a state of the gatherer object than, the gatherer will be considered in 
    //gathering state (IsGathering = true) if the gatherer object is added into the Gatherelist any one of
    //the resource node and is considered placeddown.

    private void FixedUpdate()
    {
        //Changes the state of the gatherer to Gathering
        if (IsPlacedDown)
        {
            IsGathering = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Resources OutLine"))
        {
            Debug.Log("Place");
            IsPlaceabal = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Resources OutLine"))
        {
            if (IsPlaceabal)
            {
                this.transform.position = collision.transform.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Resources OutLine"))
        {
            Debug.Log("unable to place");
            IsPlaceabal = false;
        }
    }
}
