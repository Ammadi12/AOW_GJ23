using JetBrains.Annotations;
using Shady;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class move1 : MonoBehaviour
{
    
    public ScoreManager scoremanager;

    public ParticleSystem explosions;

    public GameObject wallmanager;

    public Animator anim;
    Camera cam;

    public Rigidbody body;

    float force = 150f;

    public int damage = 100;
    public int health = 200;

    bool destroyed = false;
    bool timerON = false;
    float timer = 0f;

    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        //if (gameObject.tag == "Enemy2") health = 200;
        //anim = GetComponent<Animator>();
        
        UnityEngine.Debug.Log(wallmanager.name);
//        wallmanager.GetComponent<WallBuilder>().test();
        cam = Camera.main;
        explosions = GetComponent<ParticleSystem>();
        transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.forward * force * Time.deltaTime;

        if (timerON == true) 
        {
            if (timer <= 5)
            {
                timer = timer + Time.deltaTime;
            }
            if (timer >= 5)
            {
                transform.LookAt(Vector3.zero);
                timer = 0;
                timerON = false;
            }
        }
    }

    private IEnumerator CameraShake()
    {
        float elapsed = 0f;

        cam = Camera.main;
        Vector3 OriginalPos = cam.transform.position;
        while (elapsed < 0.5f)
        {
            float x = 0f, y = 0f;
            x = Random.Range(-0.4f, 0.4f);
            y = Random.Range(-0.4f, 0.4f);
            cam.transform.position = new Vector3(cam.transform.position.x + x, cam.transform.position.y + y, cam.transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cam.transform.position = OriginalPos;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    
    public void decreaseHealth(int x)
    {
        health = health - x;

        //        anim.SetBool("hit", true);
        //        anim.SetBool("hit", false);
        anim.Play("Base Layer.bullethit", 0, 0.2f);

        if (health <= 0)
        {
            gotHit();
            Score();
            StartCoroutine(Die());
        }
    }

    public void gotHit()
    {
        StartCoroutine(CameraShake());
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            anim.SetBool("destroy1", true);
        }
        else
        {
            anim.SetBool("destroy2", true);
        }

        if (!explosions.isPlaying) explosions.Play();
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Wall2")
        {
            rot = gameObject.transform.rotation.eulerAngles;
            rot.y = collisioninfo.collider.transform.rotation.eulerAngles.y;
            Quaternion rotating = Quaternion.Euler(rot);
            transform.rotation = rotating;
            timerON = true;
        }
        else if (collisioninfo.collider.tag == "Walls")
        {
            // need to destroy dis wall
            UnityEngine.Debug.Log(collisioninfo.collider.tag);
            Destroy(collisioninfo.collider.gameObject);
            timerON = true;
        }
        else if (collisioninfo.gameObject.tag == "Enemy1")
        {
            health = health - 200;
            gotHit();
            if (health <= 0)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                Score();
                StartCoroutine(Die());
            }
        }
        else if (collisioninfo.gameObject.tag == "Enemy2")
        {
            health = health - 200;
            gotHit();
            if (health <= 0)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                Score();
                StartCoroutine(Die());
            }
        }
        else if (collisioninfo.gameObject.tag == "Tower")
        {
            UnityEngine.Debug.Log("Health do be " + health);
            Destroy(gameObject);                                      
        }
    }

    public void Score()
    {
        scoremanager.GetComponent<ScoreManager>().AddScore(10);
        scoremanager.GetComponent<ScoreManager>().AddCoins(5);
        
    }
   
}
