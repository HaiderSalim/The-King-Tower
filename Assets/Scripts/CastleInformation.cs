using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleInformation : MonoBehaviour
{
    [Header("Castle Info")]
    [SerializeField] private float Castle_Health;
    [SerializeField] private Image Health_bar;
    [SerializeField] private int Castle_Level= 1;
    private float Max_Castle_Health;

    private void Start()
    {
        Max_Castle_Health = Castle_Health;
    }
    private void Update()
    {
        Health_bar.fillAmount = Castle_Health / Max_Castle_Health;
        if (Castle_Health <= 0)
        {
            CastleDestroyed();
        }
    }

    private void CastleDestroyed()
    {
        Destroy(this.gameObject);
    }
}
