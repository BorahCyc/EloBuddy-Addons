using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace Amumu
{
    class Mode
    {
        public static void ComboExecute()
        {
            if (AddonMenu.ComboMenu["Qcb"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (target != null && target.IsValidTarget())
                {
                    var Qpred = Spells.Q.GetPrediction(target);
                    if (Qpred.HitChancePercent >= 80)
                    {
                        Spells.Q.Cast(Qpred.CastPosition);
                    }                  
                }
            }

            if (AddonMenu.ComboMenu["Wcb"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                if (target != null && target.IsValidTarget())
                {
                    Spells.W.Cast();
                }
                else
                {
                    if (Spells.W.ToggleState.Equals(2))
                    {
                        Spells.W.Cast();
                    }
                }
            }

            if (AddonMenu.ComboMenu["Ecb"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.E.Range, DamageType.Magical);
                if (target != null && target.IsValidTarget())
                {
                    Spells.E.Cast();
                }
            }         
        }

        public static void LaneClearExecute()
        {
            if (AddonMenu.LaneClear["ManaMNGlc"].Cast<Slider>().CurrentValue <= Player.Instance.ManaPercent)
            {
                if (AddonMenu.LaneClear["Wlc"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
                {
                    int count = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.W.Range, false).Count();

                    if (count >= 3)
                    {
                        Spells.W.Cast();
                    }
                }
                if (AddonMenu.LaneClear["Elc"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
                {
                    int count = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.E.Range, false).Count();

                    if (count >= 3)
                    {
                        Spells.E.Cast();
                    }
                        
                }
            }
        }

        public static void JungleClearExecute()
        {
            if (AddonMenu.JungleClear["ManaMNGjc"].Cast<Slider>().CurrentValue <= Player.Instance.ManaPercent)
            {
                if (AddonMenu.JungleClear["Wjc"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
                {
                    int count = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.W.Range, false).Count();

                    if (count >= 3)
                    {
                        Spells.W.Cast();
                    }
                }
                if (AddonMenu.JungleClear["Ejc"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
                {
                    int count = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.E.Range, false).Count();

                    if (count >= 3)
                    {
                        Spells.E.Cast();
                    }

                }
            }
        }

        public static void KillStealExecute()
        {
        }

        public static void FleeExecute()
        {
        }

    }
}
