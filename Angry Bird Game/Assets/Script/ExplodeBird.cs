using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBird : Bird
{
    public float areaLedakan;
    public float kekuatanLedakan;
    public LayerMask triggerLedakan;
    public GameObject effect;
    public GameObject BombBird;

    public override void OnCollisionEnter2D(Collision2D col)
    {
       StartCoroutine(explode());
    }
    IEnumerator explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, areaLedakan, triggerLedakan);
    
        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * kekuatanLedakan);
        }
        Instantiate(effect, BombBird.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.001f);
        Destroy(gameObject);
    }    
}
