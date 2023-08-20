using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMousCheck : MonoBehaviour
{
    public bool IsMouseover;

    private void OnMouseOver()
    {
        IsMouseover = true;
    }
}
