using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyVampireSurvior
{
    public enum TargettingType
    {
        Location,
        Target,
    }
    public interface ISlotData 
    {
        public TargettingType TargettingType { get; }
        public void Use();
    }
}