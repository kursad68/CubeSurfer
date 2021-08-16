using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    public void EnemyDispose(Icollactable ic)
    {
        ic.dispose();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Icollactable ic = collision.gameObject.GetComponent<Icollactable>();
        ICharacter iCharacter = collision.gameObject.GetComponent<ICharacter>();
        if (ic != null)
        {
            Debug.Log("çarptı");
            EnemyDispose(ic);
            
        }
        if (iCharacter != null)
        {
            GameManager.Instance.GameEnd(false);
        }
    }
  
}
