using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathWoman : MonoBehaviour
{
    public bool IsLooking { get; private set; }
    private Animator _animator;

    public void LookAtTable()
    {
        StartCoroutine(LookingAtTable());
    }

    private IEnumerator OffsetLook()
    {
        yield return new WaitForSeconds(5);
        LookAtTable();
    }

    private IEnumerator LookingAtTable()
    {
        //Debug.Log("Look");
        IsLooking = false;
        _animator.SetBool("IsLooking", IsLooking);
        //_animator.Play("LookAtTable");
        yield return new WaitForSeconds(10);
        //_animator.Play("StopLookAtTable");
        IsLooking = true;
        _animator.SetBool("IsLooking", IsLooking);
        StartCoroutine(OffsetLook());
    }

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        LookAtTable();
    }
}
