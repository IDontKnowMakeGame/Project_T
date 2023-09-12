using System;
using System.Collections.Generic;

namespace Scripts.Behaviours.Enemy.AI.Base
{
    [Serializable]
    public class Conditions
    {
        public List<Condition> list = new();

        public bool Check()
        {
            var result = true;
            
            foreach (var condition in list)
            {
                if (condition.isImportant)
                {
                    result |= condition.Check() != condition.isNegated;
                }
                else
                {
                    result &= condition.Check() != condition.isNegated;
                }
            }

            return result;
        }
    }
}