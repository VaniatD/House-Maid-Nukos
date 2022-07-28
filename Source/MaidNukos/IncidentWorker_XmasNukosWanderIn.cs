using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace MaidNukos
{
    public class IncidentWorker_XmasNukosWanderIn : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            if (GenLocalDate.DayOfYear(map) == 58)
            {
                return true;
            }
            else return false;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            
            Map map = (Map)parms.target;
            //Log.Message("day of year :"+GenLocalDate.DayOfYear(map));
            if (!RCellFinder.TryFindRandomPawnEntryCell(out IntVec3 intVec, map, CellFinder.EdgeRoadChance_Animal, false, null))
            {
                return false;
            }
            PawnGenerationRequest request = new PawnGenerationRequest(NukosDefOf.XmasMaidnukos);
            Pawn pawn = PawnGenerator.GeneratePawn(request);
            //pawn.gender = Gender.Female;
            IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 6, null);
            GenSpawn.Spawn(pawn, loc, map, Rot4.Random);
            pawn.SetFaction(Faction.OfPlayer, null);
            PawnGenerationRequest request2 = new PawnGenerationRequest(NukosDefOf.XmasMaidnukos);
            Pawn pawn2 = PawnGenerator.GeneratePawn(request2);
            //pawn2.gender = Gender.Male;
            IntVec3 loc2 = CellFinder.RandomClosewalkCellNear(intVec, map, 6, null);
            GenSpawn.Spawn(pawn2, loc2, map, Rot4.Random);
            pawn2.SetFaction(Faction.OfPlayer, null);
            string label = "LetterLabelXmasNukosWanderIn".Translate();
            string text = "LetterXmasNukosWanderIn".Translate();
            Find.LetterStack.ReceiveLetter(label, text, LetterDefOf.PositiveEvent, new TargetInfo(pawn), null);
            //new TargetInfo(intVec, map, false)
            return true;
        }
    }
}
