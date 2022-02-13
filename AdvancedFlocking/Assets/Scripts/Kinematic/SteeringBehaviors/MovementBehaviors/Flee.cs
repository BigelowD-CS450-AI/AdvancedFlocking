using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Seek
{
    protected override Vector3 getVecDistance(Vector3 targetPosition)
    {
        return character.transform.position - targetPosition;
    }
}
