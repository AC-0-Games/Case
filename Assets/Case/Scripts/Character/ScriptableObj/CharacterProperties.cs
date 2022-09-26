using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Case.Characters
{
    [CreateAssetMenu(fileName = ("new Character"), menuName = ("Character"))]
    public class CharacterProperties : ScriptableObject
    {
        public int Healty;
        public int Attack;
        public float Speed;
        public float Range;


    }
}
