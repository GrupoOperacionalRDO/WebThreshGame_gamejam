﻿using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour
{

	private ThreshBehaviour thresh;
	private Score scoreController;

	private int rangeCost = 2;
	private int speedCost = 2;
	private int incomeCost = 2;

	private int rangeLevel = 0;
	private int speedLevel = 0;
	private int incomeLevel = 0;

    public int RangeCost { get { return rangeCost; } }
    public int SpeedCost { get { return speedCost; } }
    public int IncomeCost { get { return incomeCost; } }

    public int RangeLevel { get { return rangeLevel; } }
    public int SpeedLevel { get { return speedLevel; } }
    public int IncomeLevel { get { return incomeLevel; } }

	void Awake ()
	{
		thresh = GameObject.FindObjectOfType<ThreshBehaviour> ();
		scoreController = GameObject.FindObjectOfType<Score>();
	}

    #if UNITY_EDITOR
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				Debug.Log("Upgrade cheat!");
				UpgradeSpeed();
				UpgradeIncome();
				UpgradeRange();
			}
		}
    #endif

	public bool UpgradeSpeed()
	{
		if (scoreController.UseScore(speedCost))
		{
			thresh.speed += 0.5f;
			speedLevel++;
			speedCost *= 2;
			return true;
		}
		return false;
	}
	
	public bool UpgradeIncome()
	{
		if (scoreController.UseScore(incomeCost))
		{
			thresh.value += 1;
			incomeLevel++;
			incomeCost *= 2;
			return true;
		}
		return false;
	}

	public bool UpgradeRange()
	{
		if (scoreController.UseScore(rangeCost))
		{
			thresh.maxRange += 3f;
			rangeLevel++;
			rangeCost *= 2;
			return true;
		}
		return false;
	}
}
