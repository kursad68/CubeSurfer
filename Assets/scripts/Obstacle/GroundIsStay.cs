using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundIsStay : MonoBehaviour
{
    

    private void OnCollisionStay(Collision collision)
    {
        ICharacter ic = collision.gameObject.GetComponentInParent<ICharacter>();
        if (ic != null)
        {
            Debug.Log("hızlandı");
            EventManager.OnSpeedCharacter.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        ICharacter ic = collision.gameObject.GetComponentInParent<ICharacter>();
        if (ic != null)
        {
            Debug.Log("yavaşladı");
            EventManager.OnSpeedCharacterExit.Invoke();
        }
    }
}
