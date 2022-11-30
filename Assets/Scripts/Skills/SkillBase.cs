using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : DisableAfterSec
{
    public int damage;
    public abstract void HitEffect();

}
