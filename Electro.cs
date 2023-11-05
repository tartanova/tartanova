using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electro : MonoBehaviour
{
    private float Damage;
    //звук
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ShotClip;
    private void Start()
    {
        Damage = PlayerPrefs.GetFloat("PDamage") /4 * PlayerPrefs.GetFloat("PDamBo");
        StartCoroutine(Sound());
    }
    IEnumerator Sound()
    {
        while (true)
        {
            audioSource.PlayOneShot(ShotClip);
            yield return new WaitForSeconds(1);
        }
    }
    private void OnParticleCollision(GameObject coll)
    {
        if (coll.gameObject.tag == "Meteorit") { coll.transform.GetComponent<EnemyScript>().TakeDamage(Damage);}
    }
   
}
