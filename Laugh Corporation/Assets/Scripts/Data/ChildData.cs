using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ChildData", menuName = "Data/ChildData")]
    public class ChildData : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public List<Statistic> StatsList;
    }

    [Serializable]
    public struct Statistic
    {
        public Skill Skill;
        [Range(0,10)]
        public int Amout;
    }
    public enum Skill
    {
        Music,
        Sport,
        Humor,
        DarkHumor,
        TV
    }
}