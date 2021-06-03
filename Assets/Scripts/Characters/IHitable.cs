using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public interface IHitable
    {
        void GetHit(float value);

        bool CompareType(CharacterType comparedType);
    }
}
