using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnSpeedCharacter = new UnityEvent();
    public static UnityEvent OnSpeedCharacterExit = new UnityEvent();
    public static Action<GameObject> onPuanAction;
    public static Action<string> OnAnim;
    public static Func<CharacterControler> OnCharacter;
}
