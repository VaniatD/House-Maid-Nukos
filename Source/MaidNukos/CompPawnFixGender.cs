using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine.Assertions.Must;
using Verse;

namespace MaidNukos
{
    public class CompPawnFixGender : ThingComp
    {
        public CompProperties_PawnFixGender Props
        {
            get
            {
                return this.props as CompProperties_PawnFixGender;
            }
        }

        /*public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            if (!respawningAfterLoad)
            {
                if (GenDate.DaysPassed >= this.Props.activeOnDays)
                {
                    Pawn pawn = this.parent as Pawn;
                    if (pawn != null)
                    {
                        if (this.Props.fixedGender != Gender.None && pawn.gender != this.Props.fixedGender)
                        {
                            pawn.gender = this.Props.fixedGender;
                            pawn.Drawer.renderer.graphics.ResolveAllGraphics();
                        }
                    }
                }
                
            }
            
        }*/

        public override void PostPostMake()
        {
            base.PostPostMake();
            if (GenDate.DaysPassed >= this.Props.activeOnDays)
            {
                Pawn pawn = this.parent as Pawn;
                if (pawn != null)
                {
                    if (this.Props.fixedGender != Gender.None && pawn.gender != this.Props.fixedGender)
                    {
                        pawn.gender = this.Props.fixedGender;
                        //pawn.Drawer.renderer.graphics.ResolveAllGraphics();
                    }
                }
            }
        }

    }



    public class CompProperties_PawnFixGender : CompProperties
    {
        public CompProperties_PawnFixGender()
        {
            this.compClass = typeof(CompPawnFixGender);
        }

        public Gender fixedGender = Gender.None;

        public int activeOnDays = 5;
    }
}
