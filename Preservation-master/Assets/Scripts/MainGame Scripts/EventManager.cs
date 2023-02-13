using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    private static PolicyManager pm = new PolicyManager();
    
    //Asks the policy manager if a certain policy within a certain tree has been passed
    public bool isPassedPolicy (int reqTree, int reqIndex)
    {
        pm.setReqTree(reqTree);
        pm.setReqIndex(reqIndex);

        return pm.currIsPassed();
    }





}
