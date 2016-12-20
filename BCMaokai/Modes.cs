using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Events;

namespace BCMaokai
{
    class Modes
    {
        //Combo
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
                var Count = Player.Instance.CountEnemiesInRange(Spells.R.Range - 100);
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
        //LaneClear
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
        //JungleClear
        public static void DoJungleClear()
        {
            if (AddonMenu.JungleClear["Ejc"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x.IsMonster && x.IsValidTarget(Spells.E.Range)).OrderBy(x => x.MaxHealth).LastOrDefault();
                if (monster == null || !monster.IsValid) return;
                if (Orbwalker.IsAutoAttacking) return;
                Orbwalker.ForcedTarget = null;
                if (AddonMenu.JungleClear["Ejc"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
                {
                    Spells.E.Cast(monster);
                }
            }
            if (AddonMenu.JungleClear["Wjc"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x != null && x.IsMonster && x.IsValidTarget(Spells.W.Range)).OrderBy(x => x.MaxHealth).LastOrDefault();
                if (monster != null)
                {
                    Spells.W.Cast(monster);
                }
            }
            if (AddonMenu.JungleClear["Qjc"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x.IsMonster && x.IsValidTarget(Spells.Q.Range)).OrderBy(x => x.MaxHealth).LastOrDefault();
                if (monster == null || !monster.IsValid) return;
                if (Orbwalker.IsAutoAttacking) return;
                Orbwalker.ForcedTarget = null;
                if (AddonMenu.JungleClear["Qjc"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
                {
                    Spells.Q.Cast(monster);
                }
            }
        }
        //KillSteal
        public static void DoKillSteal()
        {
            if (AddonMenu.MiscMenu["Qks"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                var Target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.Q.IsInRange(t)
                    && t.Health <= DamageIndicator.QDMG(t)), DamageType.Magical);
                if (Target != null)
                {
                    var pred = Spells.Q.GetPrediction(Target);
                    if (pred.CollisionObjects.Length == 0)
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (AddonMenu.MiscMenu["Wks"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                var Target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.W.IsInRange(t)
                    && t.Health <= DamageIndicator.WDMG(t)), DamageType.Magical);
                if (Target != null)
                {
                    Spells.W.Cast();
                }
            }
            if (AddonMenu.MiscMenu["Eks"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                var Target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.E.IsInRange(t)
                    && t.Health <= DamageIndicator.WDMG(t)), DamageType.Magical);
                if (Target != null)
                {
                    var Epred = Spells.E.GetPrediction(Target);
                    {
                        Spells.E.Cast(Epred.CastPosition);
                    }
                }
            }
            if (AddonMenu.MiscMenu["Rks"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                var Target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.R.IsInRange(t)
                    && t.Health <= DamageIndicator.WDMG(t)), DamageType.Magical);
                if (Target != null)
                {
                    if (Spells.R.ToggleState.Equals(2))
                    {
                        Spells.R.Cast();
                    }
                }
            }
        }
        //AntiGapcloser
        public static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs args)
        {
            if (Spells.Q.IsReady()
                && sender != null
                && sender.IsEnemy
                && sender.IsValid
                && (sender.IsAttackingPlayer || Player.Instance.Distance(args.End) < 200 || args.End.IsInRange(Player.Instance, Spells.W.Range))
                && AddonMenu.MiscMenu["Qag"].Cast<CheckBox>().CurrentValue)
            {
                Spells.Q.Cast(args.End);
            }
        }
    }
}
