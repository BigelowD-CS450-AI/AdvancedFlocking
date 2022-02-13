using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        // --- replace me ---
        Vector3 direction = target.transform.position - character.transform.position;
        return 180 * Mathf.Atan2(direction.x, direction.z) / Mathf.PI;
        // ------------------
    }
}
