using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Modifier
{
    public double AdditiveValue;
    public StatType AffectedStatType;

    public Modifier(StatType affectedStatType, double additiveValue)
    {
        AffectedStatType = affectedStatType;
        AdditiveValue = additiveValue;
    }
    public double Apply(double PreValue)
    {

        return PreValue + AdditiveValue;
    }
}

