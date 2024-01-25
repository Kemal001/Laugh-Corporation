using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ChildDataLibrary", menuName = "Data/ChildDataLibrary")]
    public class ChildDataLibrary : ScriptableObject
    {
        public List<ChildData> ChildDatas;
    }
}
