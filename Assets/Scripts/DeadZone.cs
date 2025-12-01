using UnityEngine;
using System; 
public class DeadZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    public static event Action OnBallDestroyed;
    public static event Action OnGrabbableDestroyed;

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Constants.PERK_LAYER)
        {
            Destroy(other.gameObject);
            OnGrabbableDestroyed?.Invoke();
            Debug.Log("Perk destroyed");
        }
        if (other.gameObject.layer == Constants.BALL_LAYER)
        {
            OnBallDestroyed?.Invoke();
            Destroy(other.gameObject);
            Debug.Log("Ball Destroyed");
        }
    }


    // Update is called once per frame
    void Update()
    {
        

    }
}
