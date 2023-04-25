using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStep : MonoBehaviour
{
    public AudioSource _soundStep;
    public AudioSource _soundRun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f)
        {
            if (_soundStep.isPlaying) return;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (_soundStep.isPlaying) _soundStep.Stop();
                _soundRun.Play();
            }
            else
            {
                if (_soundRun.isPlaying) _soundRun.Stop();
                _soundStep.Play();
            }
        }
        else
        {
            _soundStep.Stop();
            _soundRun.Stop();
        }
    }
}
