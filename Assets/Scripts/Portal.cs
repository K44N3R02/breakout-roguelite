using UnityEngine;
using System.Collections;
public class Portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Transform OtherPortal;
    public float ExitDistance = 0.5f;

    private static float LastPortalTime;
    private float WaitTime = 0.5f;
    
    bool IsInLayerMask(int layer , LayerMask mask)
    {
        return  ( mask.value & ( 1 << layer  )) >0 ; 
    }
    
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(IsInLayerMask(other.gameObject.layer, LayerMask.GetMask("Ball")) && Time.time > LastPortalTime + WaitTime)
        {
            Rigidbody2D rb  = other.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                Teleport(rb, other.transform);
            }
           
        }




    }
    // Update 
    // 
    void Teleport(Rigidbody2D rb , Transform obj)
    {
         Vector3 localSpeed= transform.InverseTransformDirection(rb.linearVelocity);
            Vector3 newspeed = OtherPortal.TransformDirection(localSpeed);

            rb.linearVelocity = newspeed;

            Vector3 newPos = OtherPortal.position ;
            newPos += newspeed.normalized * ExitDistance;

            obj.position = newPos;
            LastPortalTime = Time.time;


    }
   
}
