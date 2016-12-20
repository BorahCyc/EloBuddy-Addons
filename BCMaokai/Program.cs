using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace BCMaokai
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Maokai) return;

            Chat.Print("BCMaokai Loaded!");

            Game.OnTick += Ontick;
            AddonMenu.DesignMenu();
            Spells.LoadSpells();
            Drawing.OnDraw += OnDraw;
            Drawing.OnEndScene += DamageIndicator.Damage_Indicator;
            Gapcloser.OnGapcloser += Modes.Gapcloser_OnGapcloser;
        }

        private static void Ontick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            { Modes.DoCombo(); }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            { Modes.DoLaneClear(); }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            { Modes.DoJungleClear(); }
            Modes.DoKillSteal();
        }

        private static void OnDraw(EventArgs args)
        {
            if (AddonMenu.DrawMenu["draw"].Cast<CheckBox>().CurrentValue)
            {
                if (AddonMenu.DrawMenu["Qdr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.Q.IsLearned ? Color.HotPink : Color.Zero, Spells.Q.Range, Player.Instance.Position);
                }
                if (AddonMenu.DrawMenu["Wdr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.W.IsLearned ? Color.Cyan : Color.Zero, Spells.W.Range, Player.Instance.Position);
                }
                if (AddonMenu.DrawMenu["Edr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.R.IsLearned ? Color.Yellow : Color.Zero, Spells.R.Range, Player.Instance.Position);
                }
                if (AddonMenu.DrawMenu["Rdr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.R.IsLearned ? Color.Yellow : Color.Zero, Spells.R.Range, Player.Instance.Position);
                }
            }
        }
    }
}
