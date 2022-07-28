using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MaidNukos
{
    [DefOf]
    public class NukosDefOf
    {
        static NukosDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(NukosDefOf));
        }

        public static PawnKindDef Maidnukos;

        public static PawnKindDef XmasMaidnukos;

        public static ThingDef MaidnukosHair;

    }

    [DefOf]
    public class CTNThingDefOf
    {
        public static ThingDef Maidnukos;
    }
}
