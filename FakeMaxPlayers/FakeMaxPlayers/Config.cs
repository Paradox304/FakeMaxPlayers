using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMaxPlayers
{
    public class Config : IRocketPluginConfiguration
    {
        public byte CustomMaxPlayers { get; set; }

        public void LoadDefaults()
        {
            CustomMaxPlayers = 48;
        }
    }
}
