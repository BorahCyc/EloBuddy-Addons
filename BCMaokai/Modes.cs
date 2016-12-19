using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace BCMaokai
{
    class Modes
    {
        public static void DoCombo()
        {
            if (AddonMenu.ComboMenu["Ecb"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
            {
                var Target = TargetSelector.GetTarget(Spells.E.Range, DamageType.Magical);
                if (Target != null && Target.IsValid())
                {
                    var Epred = Spells.E.GetPrediction(Target);
                    {
                        Spells.E.Cast(Epred.CastPosition);
                    }
                }
            }
            if (AddonMenu.ComboMenu["Wcb"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                var Target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                if (Target != null && Target.IsValid())
                {
                    Spells.W.Cast(Target);
                }
                
            }
            if (AddonMenu.ComboMenu["Qcb"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                var Target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                if (Target != null && Target.IsValid())
                {
                    var Qpred = Spells.Q.GetPrediction(Target);
                    if (Qpred.CollisionObjects.Length == 0)
                    {
                        Spells.Q.Cast(Qpred.CastPosition);
                    }
                }                
            }
            if (AddonMenu.ComboMenu["Rcb"].Cast<CheckBox>().CurrentValue && Spells.R.IsReady())
            {
                var Target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                var Count = Player.Instance.CountEnemiesInRange(Spells.R.Range - 50);
                if (Count >= AddonMenu.ComboMenu["RcbENM"].Cast<Slider>().CurrentValue)
                {
                    if (Spells.R.ToggleState.Equals(1))
                    {
                        Spells.R.Cast();
                    }
                }
                if (Count < AddonMenu.ComboMenu["RcbENM"].Cast<Slider>().CurrentValue)
                {
                    if (Spells.R.ToggleState.Equals(2))
                    {
                        Spells.R.Cast();
                    }
                }
            }
        }
        public static void DoLaneClear()
        {
            if (AddonMenu.LaneClear["ManaMNGlc"].Cast<Slider>().CurrentValue <= Player.Instance.ManaPercent)
            {
                if (AddonMenu.LaneClear["Qlc"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
                {
                    var minion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsValidTarget(Spells.Q.Range) && Spells.Q.IsInRange(m)).FirstOrDefault();
                    {
                        if (minion != null)
                        {
                            Spells.Q.Cast(minion);
                        }
                    }
                }
                if (AddonMenu.LaneClear["Wlc"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
                {
                    var minion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsValidTarget(Spells.W.Range) && Spells.W.IsInRange(m)).FirstOrDefault();
                    {
                        if (minion != null)
                        {
                            Spells.W.Cast(minion);
                        }
                    }
                }
                if (AddonMenu.LaneClear["Elc"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
                {
                    var minion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsValidTarget(Spells.E.Range) && Spells.E.IsInRange(m)).FirstOrDefault();
                    {
                        if (minion != null)
                        {
                            Spells.E.Cast(minion);
                        }
                    }
                }
            }
        }
        public static void DoJungleClear()
        {
        }
    }
}
