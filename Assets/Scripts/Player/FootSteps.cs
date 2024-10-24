using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] _footStepClips;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;

    public float _footStepThreshold;
    public float _footStepRate;
    private float _footStepTime;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(_rigidbody.velocity.y) < 0.1f)
        {
            if(_rigidbody.velocity.magnitude > _footStepThreshold)
            {
                if(Time.time - _footStepTime > _footStepRate)
                {
                    _footStepTime = Time.time;
                    _audioSource.PlayOneShot(_footStepClips[Random.Range(0, _footStepClips.Length)]);
                }
            }
        }
    }
}
