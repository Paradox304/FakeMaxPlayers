using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FakeMaxPlayers
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            Logger.Log("FakeMaxPlayers has been loaded");

            Level.onPostLevelLoaded += OnLevelLoaded;

            if (Level.isLoaded)
            {
                SetMaxPlayers(Configuration.Instance.CustomMaxPlayers);
            }
        }

        protected override void Unload()
        {
            Logger.Log("FakeMaxPlayers has been unloaded");

            Level.onPostLevelLoaded -= OnLevelLoaded;
        }

        private void OnLevelLoaded(int level)
        {
            SetMaxPlayers(Configuration.Instance.CustomMaxPlayers);
        }

        public void SetMaxPlayers(byte amount)
        {
            try
            {
                typeof(Provider)?.GetField("_maxPlayers", BindingFlags.NonPublic | BindingFlags.Static)
                    ?.SetValue(null, amount);
                Logger.Log($"Set Max Players to {amount}");
            }
            catch (Exception e)
            {
                Logger.LogException(e, "Issue changing max players");
            }
        }
    }
}
