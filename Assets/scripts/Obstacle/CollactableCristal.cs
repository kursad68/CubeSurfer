using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CollactableCristal : MonoBehaviour, Icollactable
{
 
    public void dispose()
    {
        Destroy(gameObject);
    }

    public void use()
    {
        
    }
    public void useS(GameObject gameObjects)
    {

        Sequence sq = DOTween.Sequence();
        sq.Append(transform.DOMoveY(gameObjects.transform.position.y + 9, 3f)).Join(transform.DOMoveZ(gameObjects.transform.position.z - 9, 3f)).OnUpdate(() =>
        {
            transform.position += transform.forward * 2 * Time.timeScale;
        }).OnComplete(()=>dispose());
    }
    private void OnTriggerEnter(Collider other)
    {
        ICharacter ic = other.gameObject.GetComponentInParent<ICharacter>();
        if (ic != null)
        {
            GameManager.Instance.CristalPoint(1);
            useS(other.gameObject);
         
        }
    }
}
