using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Utils
{
    public static List<ResourceAmount> Rsc(
        ResourceType? type1 = null, int amount1 = 0,
        ResourceType? type2 = null, int amount2 = 0,
        ResourceType? type3 = null, int amount3 = 0,
        ResourceType? type4 = null, int amount4 = 0
        )
    {
        var result = new List<ResourceAmount>();
        if (type1.HasValue)
        {
            result.Add(new ResourceAmount(amount1, type1.Value));
        }
        if (type2.HasValue)
        {
            result.Add(new ResourceAmount(amount2, type2.Value));
        }
        if (type3.HasValue)
        {
            result.Add(new ResourceAmount(amount3, type3.Value));
        }
        if (type4.HasValue)
        {
            result.Add(new ResourceAmount(amount4, type4.Value));
        }

        if(result.Any(x => result.Count(y => y.Type == x.Type) > 1))
        {
            throw new Exception("Type is meerderen keren toegevoegd; hoort niet!");
        }

        return result;
    }
}