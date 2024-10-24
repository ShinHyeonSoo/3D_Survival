using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioSource _audioSource;
    public float _fadeTime;
    public float _maxVolume;
    private float _targetVolume;

    // Start is called before the first frame update
    void Start()
    {
        _targetVolume = 0f;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _targetVolume;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Approximately : 근사값 처리
        if (!Mathf.Approximately(_audioSource.volume,_targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, 
                (_maxVolume / _fadeTime) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _targetVolume = _maxVolume;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _targetVolume = 0f;
        }
    }
}
