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
            if (Player.Instance.Hero != Champion.Amumu)
            {
                Chat.Print("Amumu Loaded!");
            }
            Game.OnTick += OnTick;
            AddonMenu.CreateMenu();
            Spells.LoadSpells();
        }

        private static void OnTick(EventArgs args)
        {
            
        }

    }
}
