using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Gaterer : MonoBehaviour
{
    [SerializeField] int GatheringAmount = 1;
    public bool IsPlaceabal = false;
    public bool IsPlacedDown = false;
    public bool IsGathering = false;

    private void FixedUpdate()
    {
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
