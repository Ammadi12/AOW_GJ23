using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSmoke : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playy()
    {
        ps = GetComponent<ParticleSystem>();
        Debug.Log(ps.name);
        if (!ps.isPlaying)
        {
            ps.Play();
        }
    }

    public void Stopp()
    {
        if (ps.isPlaying) ps.Stop();
    }
}
