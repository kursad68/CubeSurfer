using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Swerve;

public class CharacterControler : MonoBehaviour,ICharacter
{
    public float speed;
    Character character;
    Character Character { get { return (character == null) ? character = GetComponentInParent<Character>() : character; } }
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }
    Sequence sq;
    public GameObject EmptyObje;
    private void Start()
    {
        
        DOTween.Init();
    }

    public void move()
    {
        Swerve.SwerveController.MoveOnLine(transform, speed*2);
        Swerve.SwerveController.MoveAndRotateOnAxis(transform, 5f, false, true, false, EnumHolder.Axis.x, 0.5f, 30f, 5f);
       
       // Character.transform.position += Character.transform.forward * 2.2f * speed * Time.deltaTime;

    }
    private void OnEnable()
    {

        EventManager.onPuanAction += CreateFrienlyObstacle;
        EventManager.OnSpeedCharacter.AddListener(() => speed = 6f);
        EventManager.OnSpeedCharacterExit.AddListener(() => speed = 2f);
        EventManager.OnAnim += AnimControl;
        EventManager.OnCharacter += ch;
    }
    private void OnDisable()
    {
        EventManager.onPuanAction -= CreateFrienlyObstacle;
        EventManager.OnSpeedCharacter.RemoveListener(() => speed = 6f);
        EventManager.OnSpeedCharacterExit.RemoveListener(() => speed = 2f);
        EventManager.OnAnim -= AnimControl;
        EventManager.OnCharacter -= ch;


    }
    CharacterControler ch()
    {
        return GetComponent<CharacterControler>();
    }
    private void AnimControl(string s)
    {
        Animator.SetTrigger(s);
    }
    
  //  private void jumpPlayer()
    //{
    
      //  sq = DOTween.Sequence();
        //transform.DOLocalJump(transform.position,3f,1,1f).OnUpdate(()=> {
       // Character.transform.position += Character.transform.forward * 2 * speed * Time.deltaTime;
    //});
    
   // }
    private void CreateFrienlyObstacle(GameObject gameObject)
    {

       transform.position += Vector3.up*0.3f;
       
     // character.Rigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z));
      //  transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        GameObject CreateFriendBox = Instantiate(gameObject,new Vector3(transform.position.x,0,transform.position.z),Quaternion.identity);
        CreateFriendBox.transform.SetParent(transform);
        CreateFriendBox.transform.localScale = Vector3.one;
        AnimControl("Jump");
    }

    void Update()
    {
        move();
    }
    IEnumerator Coroutine()
    {
        
        yield return new WaitForSecondsRealtime(2); 
      
    }
}
