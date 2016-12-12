using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;

namespace Amumu
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (!Player.Instance.Hero.Equals(Champion.Amumu)) return;
            try
            {
                Game.OnTick += OnTick;
                AddonMenu.CreateMenu();
                Spells.LoadSpells();
                Chat.Print("Amumu Loaded!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void OnTick(EventArgs args)
        {
            if (Player.Instance.IsDead) return;

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            { Mode.ComboExecute(); } 
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            { Mode.LaneClearExecute(); } 
            //if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            //{ Mode.JungleClearExecute(); }
            //if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
            //{ Mode.FleeExecute(); }
        }

    }
}
