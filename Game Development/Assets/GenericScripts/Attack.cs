using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
    public abstract void DoAttack(StateController controller = null, PlayerStats playerStats = null, DefaultEnemyStats enemyStats = null);
}
