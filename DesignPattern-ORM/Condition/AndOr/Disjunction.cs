using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class Disjunction:SingleCondition
    {
        public Disjunction(Condition left, Condition right)
        {
            conditions = new List<Condition>();
            conditions.Add(left);
            conditions.Add(right);
        }
        public Disjunction() 
        {
            conditions = new List<Condition>();
        }
        public Disjunction(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogic()
        {
            return "OR";
        }
    }
}
