using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int speed;
    public int puan;
    [SerializeField]
    GameObject Character;
    [SerializeField]
    GameObject map1;
    [SerializeField]
    GameObject map2;
    [SerializeField]
    Text text;
    [SerializeField]
    Text FinishText;
    [SerializeField]
    Button next;
    [SerializeField]
    Button retry;
    int CristalPoints;
    public int mapSize;
    GameObject map;
    CharacterControler ch;
    public void createMaps(bool dead)
    {
        if (dead == false)
        {
            if ((mapSize % 2) == 0)
            {
                map = Instantiate(map1, new Vector3(0, 0, 0), Quaternion.Euler(0, 90, 0));
             
            }
            if ((mapSize % 2) == 1)
            {

                map = Instantiate(map2, new Vector3(0, 0, 0), Quaternion.Euler(0, 90, 0));

            }

        }else if (dead == true)
        {
            Destroy(map);
        }    
    }
    private void Start()
    {
        ch = EventManager.OnCharacter.Invoke();
        createMaps(false);
    }

    public void PlusPoint(int point)
    {
        puan += point;
        FinishText.text = puan + " X";
       

    }
    public void GameEnd(bool isFinish)
    {
        Debug.Log("end");
        if (isFinish)
        {
            FinishText.text = "";
            EventManager.OnAnim.Invoke("FinishDance");
            next.gameObject.SetActive(true);
            
            retry.gameObject.SetActive(true);
            ch.speed = 0;
        }
            
        if (isFinish == false)
        {
            FinishText.text = "";
            EventManager.OnAnim.Invoke("LostDance");
            retry.gameObject.SetActive(true);
            ch.speed = 0;
        }
    }
    public void CristalPoint(int point)
    {
        CristalPoints += point;

        text.text = "Cristal   :" + CristalPoints;
    }
 public void retryGame()
    {
        ch.speed = 2.2f;
        ch.Animator.ResetTrigger("LostDance");
        ch.Animator.ResetTrigger("FinishDance");
        EventManager.OnAnim.Invoke("Idle");
        FinishText.text = "";
        createMaps(true);
        createMaps(false);
        Character.transform.position = new Vector3(0, 0, 0);
       
        next.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);
    }
    public void nextGame()
    {
        ch.speed = 2.2f;
        ch.Animator.ResetTrigger("LostDance");
        ch.Animator.ResetTrigger("FinishDance");
        EventManager.OnAnim.Invoke("Idle");
        FinishText.text = "";
        createMaps(true);
        mapSize++;
        createMaps(false);
        Character.transform.position = new Vector3(0, 0, 0);

        next.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);
    }
}
