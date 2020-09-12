using Start.Base;
using UnityEngine;

public class BallController : BaseObject
{

    private bool _ignoreNextCollision = false;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float impulseForce = 5f;
    private Vector3 startPos;

    public override void BaseObjectAwake()
    {
        startPos = transform.position;
    }

    public override void BaseObjectStart()
    {
        
        //Debug.Log("ball controller started !");
    }


    private void OnCollisionEnter(Collision other)
    {
        if (_ignoreNextCollision == true)
            return;

        DeathPart deathPart = other.transform.GetComponent<DeathPart>();
        if (deathPart)
        {
            deathPart.HittedDeathPart();
        }
        
       
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*impulseForce,ForceMode.Impulse);
        _ignoreNextCollision = true;
        Invoke("AllowCollision",.2f);
    }

    private void AllowCollision()
    {
        _ignoreNextCollision = false;
    }

    public void ResetBallPos()
    {
        transform.position = startPos;
    }
}
