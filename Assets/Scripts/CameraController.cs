using Start.Base;
using UnityEngine;

public class CameraController : BaseObject
{
    [SerializeField] private GameObject target;
    private float _offset;
    public override void BaseObjectAwake()
    {
        _offset = transform.position.y - target.transform.position.y;
    }

    public override void BaseObjectUpdate()
    {
        Vector3 currentPos = transform.position;
        currentPos.y = target.transform.position.y + _offset;
        transform.position = currentPos;
    }
}
