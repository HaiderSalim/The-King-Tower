using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower_Attack_System : MonoBehaviour
{
    [Header("Tower Information")]
    [SerializeField] private GameObject Projectile_Spawn;
    [SerializeField] private GameObject Projectile;
    [SerializeField] protected float Projectile_Speed;
    [SerializeField] protected float Attack_Damage;
    [SerializeField] private float Attack_Radius;
    [SerializeField] private float Attack_Delay;
    private float Attack_Temp_Delay;
    [SerializeField] private LayerMask Enemy_layer;
    [SerializeField] private Transform Current_Target;
    public GameObject Tower_Radius_Indecator;
    public bool IsPlaceabal = false;
    public bool IsPlacedDown = false;

    private void Start()
    {
        Attack_Temp_Delay = Attack_Delay;
    }

    private void Update()
    {
        Collider2D[] Enemys;
        float Distance = Mathf.Infinity;
        float ClosestDistance = Mathf.Infinity;
        Enemys = Physics2D.OverlapCircleAll(this.transform.position, Attack_Radius, Enemy_layer);

        foreach (Collider2D EnemyHit in Enemys)
        {
            Distance = Vector2.Distance(this.transform.position, EnemyHit.transform.position);
            if (Distance < ClosestDistance)
            {
                ClosestDistance = Distance;
                Current_Target = EnemyHit.transform;
            }
        }
        if (Distance > Attack_Radius)
        {
            Current_Target = null;
            Attack_Delay = 0.0f;
        }


        Tower_Radius_Indecator.transform.localScale = new Vector3(Attack_Radius * 2, Attack_Radius * 2, 1);
    }

    private void FixedUpdate()
    {
        if (Current_Target != null) 
        {
            if (Attack_Delay >= Attack_Temp_Delay && IsPlacedDown)
            {
                GameObject obj = Instantiate(Projectile, Projectile_Spawn.transform.position, Quaternion.identity);
                Arrow arroecomp = obj.GetComponent<Arrow>();
                arroecomp.Target = Current_Target;
                arroecomp.Speed = Projectile_Speed;
                arroecomp.Damage = Attack_Damage;
                Attack_Delay = 0.0f;
            }
            else
            {
                Attack_Delay += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower OutLine"))
        {
            Debug.Log("Place");
            IsPlaceabal = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower OutLine"))
        {
            if(IsPlaceabal)
            {
                this.transform.position = collision.transform.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower OutLine"))
        {
            Debug.Log("unable to place");
            IsPlaceabal = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, Attack_Radius);
    }
}
