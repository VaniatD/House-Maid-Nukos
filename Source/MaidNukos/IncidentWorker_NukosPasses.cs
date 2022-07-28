using System;
using UnityEngine;
using Verse;
using RimWorld;

namespace MaidNukos
{
	public class IncidentWorker_NukosPasses : IncidentWorker
	{
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            if (map.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) || GenLocalDate.Season(map) == Season.Winter)
            {
                return false;
            }
            else if (!this.TryFindEntryCell(map, out IntVec3 intVec))
            {
                return false;
            }
            return true;
        }

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
            if (!this.TryFindEntryCell(map, out IntVec3 intVec))
            {
                return false;
            }
            PawnKindDef Nukos = NukosDefOf.Maidnukos;
            PawnGenerationRequest request = new PawnGenerationRequest(Nukos);
			int value = Rand.RangeInclusive(1, 3);
            int num = Rand.RangeInclusive(60000, 120000);
			IntVec3 invalid = IntVec3.Invalid;
			if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(intVec, map, 10f, out invalid))
			{
				invalid = IntVec3.Invalid;
			}
			Pawn pawn = null;
			for (int i = 0; i < value; i++)
			{
				IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
				pawn = PawnGenerator.GeneratePawn(request);
				GenSpawn.Spawn(pawn, loc, map, Rot4.Random);
				pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num;
				if (invalid.IsValid)
				{
					pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(invalid, map, 10, null);
				}
			}
			Find.LetterStack.ReceiveLetter("LetterLabelNukosPasses".Translate(), "LetterNukosPasses".Translate(), LetterDefOf.PositiveEvent, pawn, null);
			return true;
		}

        private bool TryFindEntryCell(Map map, out IntVec3 cell)
        {
            return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f, false, null);
        }
    }
}
