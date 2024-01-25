using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelsDatabase", menuName = "Data/LevelsDatabase")]
    public class LevelsDatabase : ScriptableObject
    {
        public List<ChildDataLibrary> Levels;
    }
}
