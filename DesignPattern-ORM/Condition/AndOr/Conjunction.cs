using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class Conjunction:SingleCondition
    {
        public Conjunction(Condition left, Condition right)
        {
            conditions = new List<Condition>();
            conditions.Add(left);
            conditions.Add(right);
        }
        public Conjunction()
        {
            conditions = new List<Condition>();
        }
        public Conjunction(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogic()
        {
            return "AND";
        }
    }
}
