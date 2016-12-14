using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using System;
using System.Linq;

namespace BCAmumu
{
    class Damages
    {
        public static float QDMG(Obj_AI_Base target)
        {
            if (Spells.Q.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 80f, 130f, 180f, 230f, 280f }[Spells.Q.Level] + 0.7f * Player.Instance.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float WDMG(Obj_AI_Base target)
        {
            if (Spells.W.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 8f, 12f, 16f, 20f, 24f }[Spells.W.Level] + (new[] { 0f, 0.01f, 0.015f, 0.02f, 0.025f, 0.03f }[Spells.W.Level] + 0.01f * Player.Instance.TotalMagicalDamage) * target.MaxHealth);
            else
                return 0f;
        }
        public static float EDMG(Obj_AI_Base target)
        {
            if (Spells.E.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 75f, 100f, 125f, 150f, 175f }[Spells.E.Level] + 0.5f * ObjectManager.Player.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float RDMG(Obj_AI_Base target)
        {
            if (Spells.R.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 150f, 250f, 350f }[Spells.R.Level] + 0.8f * ObjectManager.Player.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float SpellsDMG(Obj_AI_Base target)
        {
            if (target == null)
            {
                return 0;
            }
            else if (target != null)
            {
                return QDMG(target) + WDMG(target) + EDMG(target) + RDMG(target);
            }
            else return 0f;
        }
        public static void Damage_Indicator(EventArgs args)
        {
            if (AddonMenu.DrawMenu["enadr"].Cast<CheckBox>().CurrentValue)
                if (AddonMenu.DrawMenu["coldr"].Cast<CheckBox>().CurrentValue)
                {
                    foreach (var unit in EntityManager.Heroes.Enemies.Where(u => u.IsValidTarget() && u.IsHPBarRendered)
                        )
                    {

                        var damage = SpellsDMG(unit);

                        if (damage <= 0)
                        {
                            continue;
                        }
                        var Special_X = unit.ChampionName == "Jhin" || unit.ChampionName == "Annie" ? -12 : 0;
                        var Special_Y = unit.ChampionName == "Jhin" || unit.ChampionName == "Annie" ? -3 : 9;

                        var DamagePercent = ((unit.TotalShieldHealth() - damage) > 0
                            ? (unit.TotalShieldHealth() - damage)
                            : 0) / (unit.MaxHealth + unit.AllShield + unit.AttackShield + unit.MagicShield);
                        var currentHealthPercent = unit.TotalShieldHealth() / (unit.MaxHealth + unit.AllShield + unit.AttackShield + unit.MagicShield);

                        var StartPoint = new Vector2((int)(unit.HPBarPosition.X + Special_X + DamagePercent * 107) + 1,
                            (int)unit.HPBarPosition.Y + Special_Y);
                        var EndPoint = new Vector2((int)(unit.HPBarPosition.X + Special_X + currentHealthPercent * 107) + 1,
                            (int)unit.HPBarPosition.Y + Special_Y);
                        var Color = AddonMenu.DrawMenu["Color"].Cast<ColorPicker>().CurrentValue;
                        Drawing.DrawLine(StartPoint, EndPoint, 9.82f, Color);
                    }
                }
        }
    }
}