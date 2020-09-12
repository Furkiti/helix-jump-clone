using System.Collections;
using System.Collections.Generic;
using Start.Base;
using UnityEngine;

public class HelixController : BaseObject
{

    private Vector2 _lastTapPos;
    private Vector3 _startRotation;
    [SerializeField] private float rotateSpeed = 1f;


    public override void BaseObjectAwake()
    {
        _startRotation = transform.localEulerAngles;
    }

    public override void BaseObjectUpdate()
    {
        GetInputPC();
        //GetInputMobile();
    }
    
    private void GetInputPC()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPos = Input.mousePosition;

            if (_lastTapPos == Vector2.zero)
            {
                _lastTapPos = currentTapPos;
            }

            float delta = _lastTapPos.x - currentTapPos.x;
            _lastTapPos = currentTapPos;
            
            transform.Rotate(Vector3.up * delta * rotateSpeed);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lastTapPos = Vector2.zero;
        }
    }
    
    private void GetInputMobile()
    {
        throw new System.NotImplementedException();
    }
}
