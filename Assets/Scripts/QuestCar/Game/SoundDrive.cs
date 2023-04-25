using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDrive : MonoBehaviour
{
    public AudioSource _moveSoundCar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f)
        {
            if (_moveSoundCar.isPlaying) return;
            _moveSoundCar.Play();
        }
        else
        {
            _moveSoundCar.Stop();
        }
    }
}
