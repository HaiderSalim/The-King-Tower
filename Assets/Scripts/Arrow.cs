using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public Transform Target;
    [HideInInspector] public float Speed;
    [HideInInspector] public float Damage;
    [SerializeField] private Transform ArrowBase;

    private void FixedUpdate()
    {
        if (Target != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, Target.position, Speed * Time.deltaTime);
            Vector3 dir = (Target.transform.position) - (this.transform.position);
            float angle = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            ArrowBase.eulerAngles = new Vector3(0, 0, angle);
        }
        else if (Target == null)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyInformation>().Health -= Damage;
            Destroy(this.gameObject);
        }
    }
}