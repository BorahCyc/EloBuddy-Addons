using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace BCAmumu
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

            var Target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
            if (Target == null) return;
            if (AddonMenu.ComboMenu.GetValue("Wcb", false) > 0 && Spells.Q.IsReady())
            {
                if (AddonMenu.ComboMenu.GetValue("Wcb", false) == 1)
                {
                    var target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                    if (target != null && target.IsValidTarget())
                    {
                        if (Spells.W.ToggleState.Equals(1))
                        {
                            Spells.W.Cast();
                        }
                    }
                    else
                    {
                        if (Spells.W.ToggleState.Equals(2))
                        {
                            Spells.W.Cast();
                        }
                    }
                }
                if (AddonMenu.ComboMenu.GetValue("Q", false) == 2)
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
                if (AddonMenu.ComboMenu["Rcb"].Cast<CheckBox>().CurrentValue && Spells.R.IsReady())
                {
                    var Count = EntityManager.Heroes.Enemies.Count(x => x.IsValid && Spells.R.IsInRange(x));
                    if (Count >= AddonMenu.ComboMenu["RcbENM"].Cast<Slider>().CurrentValue)
                    {
                        Spells.R.Cast();
                    }
                }
            }
        }

        public static void LaneClearExecute()
        {
            if (AddonMenu.LaneClear["ManaMNGlc"].Cast<Slider>().CurrentValue <= Player.Instance.ManaPercent)
            {
                if (AddonMenu.LaneClear["Wlc"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
                {
                    var lanemobs = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, Spells.W.Range);
                    if (lanemobs != null)
                    {
                        if (Spells.W.ToggleState.Equals(1))
                        {
                            Spells.W.Cast();
                        }
                    }
                    else
                    {
                        if (Spells.W.ToggleState.Equals(2))
                        {
                            Spells.W.Cast();
                        }
                    }
                }
                if (AddonMenu.LaneClear["Elc"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
                {
                    var lanemobs = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, Spells.E.Range);
                    if (lanemobs != null)
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
                if (AddonMenu.JungleClear["Qjc"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
                {
                    var junglemobs = EntityManager.MinionsAndMonsters.GetJungleMonsters();
                    if (junglemobs != null)
                    {
                        Spells.Q.Cast();
                    }
                   
                }

                if (AddonMenu.JungleClear["Wjc"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
                {
                    var junglemobs = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Spells.W.Range);
                    if (junglemobs != null)
                    {
                        if (Spells.W.ToggleState.Equals(1))
                        {
                            Spells.W.Cast();
                        }
                    }
                    else
                    {
                        if (Spells.W.ToggleState.Equals(2))
                        {
                            Spells.W.Cast();
                        }
                    }
                }
                if (AddonMenu.JungleClear["Ejc"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
                {
                    var junglemobs = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Spells.E.Range);
                    if (junglemobs != null)
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
