using System.Collections.Generic;
using Verse;
using RimWorld;

namespace MaidNukos
{
	public class ThoughtWorker_NukosNearbySelf : ThoughtWorker
	{
		//private const float Radius = 10f;

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (!p.Spawned)
			{
				return false;
			}
			/*List<Thing> list = p.Map.listerThings.ThingsOfDef(NukosThingDefOf.Maidnukos);
			for (int i = 0; i < list.Count; i++)
			{
				if (p.Position.InHorDistOf(list[i].Position, Radius))
				{
					return true;
				}
			}*/
            foreach (Pawn pawn in p.Map.mapPawns.PawnsInFaction(Faction.OfPlayer))
            {
                if (pawn.kindDef == NukosDefOf.Maidnukos || pawn.kindDef == NukosDefOf.XmasMaidnukos)
                {
                    return true;
                }
            }
			return false;
		}
	}
}
