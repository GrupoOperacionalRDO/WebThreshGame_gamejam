﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UniqueUpgradeController : MonoBehaviour
{

	private ThreshBehaviour thresh;
	private Score scoreController;
	
	private int bounceCost = 2;
	private int multipleHookCost = 2;
    private int phaseCost = 2;

    public int BounceCost { get { return bounceCost; } }
    public int MultipleHookCost { get { return multipleHookCost; } }
    public int PhaseCost { get { return phaseCost; } }

	void Start ()
	{
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		scoreController = GameObject.FindObjectOfType<Score>();
	}

    #if UNITY_EDITOR
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				Debug.Log("Unique upgrade cheat!");
				BounceUpgrade();
				MultipleHooksUpgrade();
				PhaseUpgrade();
			}
		}
    #endif

	public bool BounceUpgrade()
	{
		if(thresh.bounce) return true;
		
		if (scoreController.UseScore(bounceCost))
		{
			thresh.bounce = true;
			return true;
		}
		
		return false;
	}

	public bool MultipleHooksUpgrade()
	{
		if (thresh.multipleHooks) return true;
		
		if (scoreController.UseScore(multipleHookCost))
		{
			thresh.multipleHooks = true;
			return true;
		}
		
		return false;
	}

	public bool PhaseUpgrade()
	{
		if (thresh.phase) return true;
		
		if (scoreController.UseScore(phaseCost))
		{
			thresh.phase = true;
			return true;
		}
		
		return false;
	}
}