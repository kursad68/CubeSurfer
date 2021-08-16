using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGround : MonoBehaviour, IObstacle
{
    public void EnemyDispose(Icollactable ic)
    {

        ic.use();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Icollactable ic = collision.gameObject.GetComponent<Icollactable>();
       ICharacter icHaracter = collision.gameObject.GetComponent<ICharacter>();
        if (ic != null)
        {
            EnemyDispose(ic);
            Destroy(collision.gameObject);

        }
        if (icHaracter != null)
        {
            GameManager.Instance.GameEnd(true);
        }
    }
}
