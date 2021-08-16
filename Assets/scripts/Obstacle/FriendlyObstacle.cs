using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyObstacle : MonoBehaviour,Icollactable
{
    public bool inToCharacter;
    public void dispose()
    {
       
        Destroy(gameObject);
        
       
    }

    public void use()
    {
        GameManager.Instance.PlusPoint(1);
    }

 

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        ICharacter ic = collision.gameObject.GetComponent<ICharacter>();
        Icollactable ip = collision.gameObject.GetComponent<Icollactable>();
        if (ic != null || ip!=null)
        {
            if (inToCharacter == true)
            {
                inToCharacter = false;
                EventManager.onPuanAction(gameObject);
                Destroy(gameObject);
               
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
