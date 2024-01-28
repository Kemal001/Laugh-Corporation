using System.Collections.Generic;
using Runtime;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Data/MonsterData")]
    public class MonsterData : ScriptableObject
    {
        public MonsterName Name;
        public List<Statistic> StatsList;
    }
}