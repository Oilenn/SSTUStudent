using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStep : MonoBehaviour
{
    public AudioSource _soundStep;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _soundStep.pitch = 2f;

            }
            else 
                _soundStep.pitch = 1.2f;

            if (_soundStep.isPlaying) return;
            _soundStep.Play();

        }
        else
        {
            _soundStep.Stop();
        }
    }
}
