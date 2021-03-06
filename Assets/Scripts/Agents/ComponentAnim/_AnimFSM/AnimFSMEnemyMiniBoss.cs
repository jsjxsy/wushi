using UnityEngine;
using System.Collections;

// add enum
// add new  - in Initialize
// add if  - in DoAction

public class AnimFSMEnemyMiniBoss: AnimFSM
{
	enum E_MyAnimState
	{
		E_IDLE,
		E_GOTO,
        E_COMBAT_MOVE,
        Rotate,
		E_ATTACK_MELEE,
        AttackRoll,
        E_PLAY_ANIM,
        E_INJURY,
        E_BLOCK,
        E_DEATH,
	}

    public AnimFSMEnemyMiniBoss(Animation anims, Agent owner) : base(anims, owner)
    {
        AnimStates.Add(new AnimStateIdle(AnimEngine, Owner)); //E_MyAnimState.E_IDLE
        AnimStates.Add(new AnimStateGoTo(AnimEngine, Owner)); //E_MyAnimState.E_GOTO
        AnimStates.Add(new AnimStateCombatMove(AnimEngine, Owner)); //E_MyAnimState.E_GOTO
        AnimStates.Add(new AnimStateRotate(AnimEngine, Owner)); //E_MyAnimState.Rotate
        AnimStates.Add(new AnimStateAttackMelee(AnimEngine, Owner)); //E_MyAnimState.E_ATTACK_MELEE
        AnimStates.Add(new AnimStateAttackRoll(AnimEngine, Owner)); //E_MyAnimState.Roll
        AnimStates.Add(new AnimStatePlayAnim(AnimEngine, Owner)); //E_MyAnimState.E_PLAY_ANIM
        AnimStates.Add(new AnimStateInjury(AnimEngine, Owner)); //E_MyAnimState.E_INJURY
        AnimStates.Add(new AnimStateBlocking(AnimEngine, Owner)); //E_MyAnimState.E_BLOCK
        AnimStates.Add(new AnimStateDeath(AnimEngine, Owner)); //E_MyAnimState._E_DEATH
    }

	public override void Initialize()
	{
        DefaultAnimState = AnimStates[(int)E_MyAnimState.E_IDLE];
		base.Initialize();
	}

	public override void DoAction(AgentAction action)
	{
		if (CurrentAnimState.HandleNewAction(action) == true)
		{
			//Debug.Log("AC - Do Action " + action.ToString());
			NextAnimState = null;
		}
		else
		{
            if (action is AgentActionGoTo)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_GOTO];
            if (action is AgentActioCombatMove)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_COMBAT_MOVE];
            else if (action is AgentActionRotate)
                NextAnimState = AnimStates[(int)E_MyAnimState.Rotate];
            else if (action is AgentActionAttack)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_ATTACK_MELEE];
            else if (action is AgentActionAttackRoll)
                NextAnimState = AnimStates[(int)E_MyAnimState.AttackRoll];
            else if (action is AgentActionWeaponShow)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_IDLE];
            else if (action is AgentActionPlayAnim || action is AgentActionPlayIdleAnim)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_PLAY_ANIM];
            else if (action is AgentActionInjury)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_INJURY];
            else if (action is AgentActionBlock)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_BLOCK];
            else if (action is AgentActionDeath)
                NextAnimState = AnimStates[(int)E_MyAnimState.E_DEATH];

            ProgressToNextStage(action);

		}
	}
}