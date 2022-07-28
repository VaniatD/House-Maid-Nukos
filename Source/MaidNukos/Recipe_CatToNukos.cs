using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;

namespace MaidNukos
{
    public class Recipe_CatToNukos : Recipe_Surgery
    {
        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            if (billDoer != null)
            {
                if (base.CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
                {
                    return;
                }
                TaleRecorder.RecordTale(TaleDefOf.DidSurgery, new object[]
                {
                    billDoer,
                    pawn
                });
                if (PawnUtility.ShouldSendNotificationAbout(pawn) || PawnUtility.ShouldSendNotificationAbout(billDoer))
                {
                    string text;
                    if (!this.recipe.successfullyRemovedHediffMessage.NullOrEmpty())
                    {
                        text = string.Format(this.recipe.successfullyRemovedHediffMessage, billDoer.LabelShort, pawn.LabelShort);
                    }
                    else
                    {
                        text = "MessageSuccessfullyCatToNukos".Translate(billDoer.LabelShort, pawn.LabelShort, billDoer.Named("SURGEON"), pawn.Named("PATIENT"));
                    }
                    Messages.Message(text, pawn, MessageTypeDefOf.PositiveEvent, true);
                }
                pawn.kindDef = NukosDefOf.Maidnukos;
                pawn.def = CTNThingDefOf.Maidnukos;
                pawn.Drawer.renderer.graphics.ResolveAllGraphics();
            }
        }
    }
}
