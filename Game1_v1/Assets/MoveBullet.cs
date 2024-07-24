using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    float timer = 5f;
    float speed = 1f;
    bool x = true;

    public int damage=5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }
        else Destroy(gameObject);
    }

    public void increaseDamage(int value)
    {
        Debug.Log("Reaches increase damage funcion");
        damage += value;
        Debug.Log("Damage is now " + damage);
    }

    public void move(GameObject target)
    {
        for (float i = 0; i < 5 && x == true && target != null; i += Time.deltaTime)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(target.transform.position, target.transform.position, step);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.000001f)
            {
                x = false;
            }
            
        }
        //Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            Debug.Log("Damage is " + damage);
//            collision.gameObject.GetComponent<move>().gotHit();
            collision.gameObject.GetComponent<move>().decreaseHealth(damage);
        }
        Destroy(gameObject);
    }

}
