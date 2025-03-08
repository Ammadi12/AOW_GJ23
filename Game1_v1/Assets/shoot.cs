using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    GameObject b;

    bool taken = false;

    float timer = 0f;
	
	public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Debug.Log(other.tag);
                if (other.tag == "Enemy1" || other.name == "Enemy2")
                {
                    GameObject x = other.gameObject;
                    // instaniate bullet here
                    // also target only this enemy1, no need to target any other enemies
                    b = Instantiate(bullet, transform);
                    b.GetComponent<MoveBullet>().move(x);
					source = GetComponent<AudioSource>();
					source.PlayOneShot(source.clip, 0.03f);
                }
            timer = 0.5f;
        }
    }
}
