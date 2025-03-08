using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollision : MonoBehaviour
{
    private Camera cam;
    Vector3 OriginalPos;

    public AudioSource source;
    public AudioClip clip;
	

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        clip = source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CameraShake()
    {
        cam = Camera.main;
        float elapsed = 0f;
        float shakeFrequency = 0.8f;
        OriginalPos = cam.transform.position;

        while (elapsed < 0.4f)
        {
            cam.transform.position = OriginalPos + Random.insideUnitSphere * shakeFrequency;
            elapsed += Time.deltaTime;
            yield return null;
        }
        cam.transform.position = OriginalPos;
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.tag == "Enemy1")
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(source.clip, 0.1f);
   			StartCoroutine(CameraShake());
            
        }
		if (collisioninfo.gameObject.tag == "Enemy2")
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(source.clip, 0.1f);
   			StartCoroutine(CameraShake());
            
        }
    }

}
