using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
	[CreateAssetMenu(menuName ="Data/Player Stat")]
	public class PlayerStatData : ScriptableObject, ISpawnableData
	{
		public int hp;
		public int moveSpeed;
		public float fireDelay;

		public float FireDelay => fireDelay;
    }
}