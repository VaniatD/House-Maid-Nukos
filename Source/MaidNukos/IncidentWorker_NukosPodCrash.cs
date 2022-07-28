using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace MaidNukos
{
    public class IncidentWorker_NukosPodCrash : IncidentWorker
    {
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            PawnGenerationRequest request = new PawnGenerationRequest(NukosDefOf.Maidnukos);
            Pawn pawn = PawnGenerator.GeneratePawn(request);
            Map map = (Map)parms.target;
            List<Thing> things = new List<Thing>
            {
                pawn
            };
            HealthUtility.DamageUntilDowned(pawn);
            if (Rand.Chance(0.4f))
            {
                PawnGenerationRequest request2 = new PawnGenerationRequest(NukosDefOf.Maidnukos);
                Pawn pawn2 = PawnGenerator.GeneratePawn(request2);
                HealthUtility.DamageUntilDowned(pawn2);
                things.Add(pawn2);
            }
            IntVec3 intVec = DropCellFinder.RandomDropSpot(map);
            string label = "LetterLabelNukosPodCrash".Translate();
            string text = "LetterNukosPodCrash".Translate();
            Find.LetterStack.ReceiveLetter(label, text, LetterDefOf.NeutralEvent, new TargetInfo(intVec, map, false), null);
            ActiveDropPodInfo activeDropPodInfo = new ActiveDropPodInfo();
            activeDropPodInfo.innerContainer.TryAddRangeOrTransfer(things, true, false);
            activeDropPodInfo.openDelay = 180;
            activeDropPodInfo.leaveSlag = true;
            DropPodUtility.MakeDropPodAt(intVec, map, activeDropPodInfo);
            return true;
        }
    }
}
