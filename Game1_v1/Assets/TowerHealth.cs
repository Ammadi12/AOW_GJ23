using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth;

    public Animator anim;
	Vector3 SmokePosition=new Vector3(6.5f, 18.0f, -6.5f);
    Vector3 OriginalPos;
    float shakeFrequency = 1f;
    Camera cam;
    [SerializeField] HealthManager healthman;

    private ParticleSystem ps;
	private GameObject smokeEffectInstance;
	private GameObject ExplosionInstance;
    private bool smokeEffectStopped = false;
	private bool smokeEffectStarted = false;
	private bool ExplosionStarted = false;
    public GameObject gameover;
    
	
    public GameObject SmokeEffectPrefab;
    public GameObject ExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        ps.Clear();
        currentHealth = maxhealth;
        healthman.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
   public void Update()
   {
	   if (currentHealth <= 50 && smokeEffectStarted==false)
        {
            PlaySmokeEffect(SmokePosition);
        }
		if (currentHealth <= 0 && ExplosionStarted==false)
        {
   
            StopSmokeEffect();
			PlayExplosion(SmokePosition);
            StartCoroutine(ShowGameOverAfterDelay());

        }
	   
   }
   
    IEnumerator ShowGameOverAfterDelay()
    {
        yield return new WaitForSeconds(1.8f);

        gameover.SetActive(true);
		Time.timeScale=0f;
    }
    public void PlaySmokeEffect(Vector3 position)
    {
        smokeEffectInstance = Instantiate(SmokeEffectPrefab, position, Quaternion.identity);
		smokeEffectInstance.transform.rotation = Quaternion.Euler(new Vector3(-45, 0, 0));
		smokeEffectStarted=true;
    }
	public void StopSmokeEffect()
    {
    
		Destroy(smokeEffectInstance);
    }
	
	public void PlayExplosion(Vector3 position)
    {
        ExplosionInstance = Instantiate(ExplosionPrefab, position, Quaternion.identity);
		ExplosionInstance.transform.rotation = Quaternion.Euler(new Vector3(-45, 0, 0));
		ExplosionStarted=true;
    }
	public void StopExplosion()
    {
    
		Destroy(ExplosionInstance);
    }
	
    public void upgradeHealth()
    {
        maxhealth += 30;
        currentHealth = maxhealth;
    }

     void decreaseHealth(int damage)
    {
        currentHealth -= damage;
        healthman.SetHealth(currentHealth);
        Debug.Log(anim.name);
        
        //if (currentHealth <= 70)
        //{
        //    SmokeHandler.GetComponent<SpawnSmoke>().Playy();
        //    //SmokeHandler.GetComponent<SpawnSmoke>().Stopp();
        //}
    }
    public int returnHealth()
    { return currentHealth; }

    private IEnumerator CameraShake()
    {
        float elapsed = 0f;

        cam = Camera.main;
        OriginalPos = cam.transform.position;
        while (elapsed < 0.5f)
        {
            float x = 0f, y = 0f;
            x = Random.Range(-0.7f, 0.7f);
            y = Random.Range(-0.7f, 0.7f);
            cam.transform.position = new Vector3(cam.transform.position.x + x, cam.transform.position.y + y, cam.transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cam.transform.position = OriginalPos;
    }

     void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.CompareTag("Enemy1"))
        {
            if (!ps.isPlaying) ps.Play();
            if (currentHealth >= 0)
            {
                StartCoroutine(CameraShake());
                decreaseHealth(10);
            }
        }
        if (collisioninfo.gameObject.CompareTag("Enemy2"))
        {
            if(!ps.isPlaying) ps.Play(); if (currentHealth >= 0)
            {
                StartCoroutine(CameraShake());  
                decreaseHealth(20);
            }
        }

        if (currentHealth <= 0)
        {
            //            Destroy(gameObject);
            anim.SetBool("IsFalling", true);
        }
    }
}
