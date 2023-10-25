using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IStateSwitcher 
{
    void SwitchState<T>() where T:IState;

}
