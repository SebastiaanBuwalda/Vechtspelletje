using UnityEngine;
using System.Collections;

public class ParticleStorer : MonoBehaviour {

    [SerializeField] private ParticleSystem partSys;
    void Update()
    {
        if(!partSys.isPlaying)
        {
            ObjectPool.instance.PoolObject(gameObject);
        }
    }
}
