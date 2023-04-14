using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMove : MonoBehaviour
{
    public Transform _TargetLimb;
    public bool _mirror;
    ConfigurableJoint _cj;

    void Start()
    {
        _cj = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_mirror)
        {
            _cj.targetRotation = _TargetLimb.rotation;
        }
        else
        {
            _cj.targetRotation = Quaternion.Inverse(_TargetLimb.rotation);
        }
    }
}
